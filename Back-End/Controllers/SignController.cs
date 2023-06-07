using Back_End.Dados;
using Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public SignController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Search()
        {
            var signs = _appDbContext.Sign;

            if (signs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(signs);
            }


        }

        // GET api/<SignosController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var sign = _appDbContext.Sign.SingleOrDefault(c => c.SignId == id);

            if (sign == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(sign);
            }


        }

        [HttpGet("encontrar-signo/{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetSignByClientId(int clientId)
        {
            var client = _appDbContext.Client.SingleOrDefault(c => c.ClientId == clientId);

            if (client == null)
            {
                return NotFound();
            }
            else
            {
                var signs = _appDbContext.Sign;
                foreach(var sign in signs)
                {
                    if (sign.VerificarSigno(client.DataNascimento.Value))
                        return CreatedAtAction(nameof(GetById), new { id = sign.SignId }, sign);

                }
                return NotFound();
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(List<SignEntityModel> signs)
        {
            foreach (var sign in signs)
            {
                _appDbContext.Sign.Add(sign);
                _appDbContext.SaveChanges();
            }
            return CreatedAtAction(nameof(GetById), new { id = string.Join(",", signs.Select(s => s.SignId)) }, signs);

        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult Update(long id, SignEntityModel signAtualizado)
        {
            var sign = _appDbContext.Sign.SingleOrDefault(d => d.SignId == id);

            if (sign == null)
            {
                return NotFound();
            }

            _appDbContext.Update(signAtualizado);

            _appDbContext.Sign.Update(sign);
            _appDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = sign.SignId }, sign);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult Delete(int id)
        {
            var sign = _appDbContext.Sign.SingleOrDefault(c => c.SignId == id);
            if (sign == null)
            {
                return NotFound();
            }
            else
            {
                _appDbContext.Sign.Remove(sign);
                _appDbContext.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = sign.SignId }, sign);
            }

        }
    }
}
