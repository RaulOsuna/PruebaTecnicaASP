using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDClienteController : ControllerBase
    {
        // GET: api/<CRUDClienteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CRUDClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CRUDClienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CRUDClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CRUDClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
