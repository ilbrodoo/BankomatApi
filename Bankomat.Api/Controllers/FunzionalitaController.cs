using AutoMapper;
using Bankomat.Api.Dto;
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
        private IMapper _mapper;
        public FunzionalitaController(IFunzionalitaDb funzionalitaDb, IMapper mapper) 
        {
            _funzionalitaDb = funzionalitaDb;
            _mapper = mapper;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<FunzionalitaDto>>> Get() 
        {
            IEnumerable<Funzionalitum> funzioni = await _funzionalitaDb.GetAllAsync();
            var funzioniDaStampare = _mapper.Map<List<FunzionalitaDto>>(funzioni.ToList());

            return Ok(funzioniDaStampare);
        }



    }
}
