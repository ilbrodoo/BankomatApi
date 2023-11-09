using Bankomat.Api.Models;
using Bankomat.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bankomat.Api.Controllers
{
    [ApiController]
    [Route("api/Funzionalità")]
    public class FunzionalitaController : Controller
    {
        private IFunzionalitaDb _funzionalitaDb;

        public FunzionalitaController(IFunzionalitaDb funzionalitaDb) 
        {
            _funzionalitaDb = funzionalitaDb;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funzionalitum>>> Get() 
        {
            var funzioni = await _funzionalitaDb.GetAllAsync();
            return Ok(funzioni);
        }
    }
}
