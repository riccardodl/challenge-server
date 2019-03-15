using BackendService.Models;
using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    public class CustomVisionServiceController : Controller
    {

        private readonly ControllerDataRepository _repository;

        public CustomVisionServiceController(BackendService.Controllers.ControllerDataRepository repository)
        {

            _repository = repository;
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
        [HttpGet("[controller]/{ship:int?}/{rope:int?}/{img:int?}")]
        public async Task<ActionResult<string>> Get(int? ship, int? rope, int? img)
        {
            if (ship != null && rope != null && img != null)
            {
                var response = _repository.MakePrediction(ship.Value, rope.Value, img.Value);
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

        // POST api/<controller>
        [HttpPost]
        public Task<IActionResult> Post([FromBody]string value)
        {
            if (Request.HasFormContentType && Request.ContentType == "application/octet-stream")
            {
                MemoryStream stream = new MemoryStream();
                await Request.Body.CopyToAsync(stream);

                      /*
                        System.IO.Image image = Image.FromStream(stream);
                        var testName = content.Headers.ContentDisposition.Name;
                        String filePath = HostingEnvironment.MapPath("~/Images/");
                        String[] headerValues = (String[])Request.Headers.GetValues("UniqueId");
                        String fileName = headerValues[0] + ".jpg";
                        String fullPath = Path.Combine(filePath, fileName);
                        image.Save(fullPath);*/
                 
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
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
    }
}
