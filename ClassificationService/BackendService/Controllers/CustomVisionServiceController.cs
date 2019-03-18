using BackendService.Models;
using BackendService.Models.ImageUploadViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendService.Controllers
{
    [Route("api/[controller]/")]
    public class CustomVisionServiceController : Controller
    {

        private readonly ControllerDataRepository _repository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CustomVisionServiceController(BackendService.Controllers.ControllerDataRepository repository, IHostingEnvironment environment)
        {

            _repository = repository;
            _hostingEnvironment = environment;
        }
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Ship>>> Get()
        {
            var Ships = await _repository.GetShipsAsync();
            if (Ships == null)
            {
                return NotFound();
            }
            return Ships;
        }
        
        // GET api/<controller>/5/3/4
        [HttpGet("{ship:int?}/{rope:int?}/{img:int?}")]
        public async Task<ActionResult<string>> Get(int? ship, int? rope, int? img)
        {
            if (ship != null && rope != null && img != null)
            {
                var response = await _repository.MakePrediction(ship.Value, rope.Value, img.Value);
                if (response.Key != null)
                {
                    var target = await _repository.GetRopeAsync(ship.Value, rope.Value);
                    Enum.TryParse(response.Key, out Tag t);
                    target.Tag = t;
                    target.Probability = response.Value;
                    return Ok(response);
                }
                return NoContent();
            }
            return NotFound();
        }

        // POST api/<controller>/shipid => Body: Image
        [HttpPost("{ship:int}/{rope:int?}/")]
        public async Task<IActionResult> Post([FromHeader] int ship, [FromHeader] int? rope)//,[FromForm] IFormFile files)
        {
            if (Request.HasFormContentType && Request.ContentType.Contains("multipart/form-data"))
            {
                var m = Request.Query;
                var myImg = Request.Form.Files.GetFile("file");
                var stream = myImg.OpenReadStream();

                int.TryParse(Request.Form["ship"].ToString(),out ship);
                rope = ToNullableInt(Request.Form["rope"]);
                
                BinaryReader binaryReader = new BinaryReader(stream);
                var imgbytes = binaryReader.ReadBytes((int)stream.Length);

                string filenameWithoutPath = Path.GetFileNameWithoutExtension(myImg.FileName);
                var uniqueFileName = _repository.NewFilename(filenameWithoutPath);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploads, uniqueFileName);

                if (imgbytes.Length > 0)
                {
                    System.IO.File.WriteAllBytes(filePath + Path.GetExtension(myImg.FileName), imgbytes);

                    Image img = new Image() { RawImage = imgbytes };
                    if( await _repository.AddImageAsync(ship,rope, img))
                    {
                        return Ok();
                    }
                }
                return NotFound();
            }
            return BadRequest();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            // image recognition service, return tag and probability
        }

        // DELETE api/<controller>/5
        //Only deletes images since is proof of concept
        [HttpDelete("{id:int?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            //Case string [FromHeader]WhichItem => call delete ship, rope or img
            if (await _repository.DeleteImageAsync(id.Value))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        public int? ToNullableInt(string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

    }

}
