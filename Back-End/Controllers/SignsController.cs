using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignsController : Controller
    {
        // GET: api/<SignosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SignosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SignosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SignosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SignosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
