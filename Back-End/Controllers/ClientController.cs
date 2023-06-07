using Back_End.Dados;
using Back_End.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ClientController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var client = _appDbContext.Client.SingleOrDefault(c => c.ClientId == id);

            if (client == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(client);
            }


        }

        // POST api/<ClienteController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(ClientEntityModel client)
        {
            _appDbContext.Client.Add(client);
            _appDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = client.ClientId }, client);

        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult Update(long id, ClientEntityModel clientAtualizado)
        {
            var client = _appDbContext.Client.SingleOrDefault(d => d.ClientId == id);

            if (client == null)
            {
                return NotFound();
            }

            client.Update(clientAtualizado);

            _appDbContext.Client.Update(client);
            _appDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = client.ClientId }, client);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult Delete(int id)
        {
            var client = _appDbContext.Client.SingleOrDefault(c => c.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                _appDbContext.Client.Remove(client);
                _appDbContext.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = client.ClientId }, client);
            }

        }
    }
}
