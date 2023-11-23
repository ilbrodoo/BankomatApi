using Bankomat.Api.Models;
using Bankomat.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Bankomat.Api.Controllers
{
    [ApiController]
    [Route("api/Banche")]
    public class BancheController : ControllerBase  // Assicurati di ereditare da ControllerBase
    {
        private IBancheDb _bancheDb;
        private IFunzionalitaDb _faunzionalitaDb;

        public BancheController(IBancheDb bancheDb)
        {
            _bancheDb = bancheDb;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banche>>> GetBancaAsync()
        {
            IEnumerable<Banche> banche = await _bancheDb.GetAllAsync();

            return Ok(banche);
        }

        [HttpGet("{BancaId}")]
        public async Task<ActionResult<Utenti>> GetBancaById(int BancaId)
        {
            var Cliente = await _bancheDb.GetBancaByIdAsync(BancaId);
            if (Cliente == null)
            {
                return BadRequest("Non trovato");
            }
            else
            {
                return Ok(Cliente);
            }
        
       }
        //[HttpGet("Funzionalita/{IdBanca}")]
        //public async Task<ActionResult<IEnumerable<Funzionalitum>>> GetFunzionalitaByBancaId(long IdBanca)
        //{
        //    try
        //    {
        //        var banca = await _bancheDb.GetBancaByIdAsync(IdBanca);

        //        if (banca == null)
        //        {
        //            return NotFound($"Banca con ID {IdBanca} non trovata");
        //        }

                

        //        return Ok(funzionalita);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Errore nel recupero delle funzionalità della banca: {ex.Message}");
        //    }
        //}

    }
}
