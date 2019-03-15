using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendService.Models;
using Microsoft.AspNetCore.Http;
using BackendService.Controllers;
using System;

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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
