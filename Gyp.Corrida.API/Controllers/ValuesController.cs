using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gyp.Corrida.Domain.Corrida;
using Microsoft.AspNetCore.Mvc;

namespace Gyp.Corrida.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRaceService _raceService;
        public ValuesController(IRaceService raceService)
        {
            _raceService = raceService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            int volta =_raceService.CalculaVolta();
            return new string[] { volta.ToString(), "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
