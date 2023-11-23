using Bankomat.Api.Repositories;
using Bankomat.Api.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Bankomat.Api.Dto;

[ApiController]
[Route("api/Clienti")]
public class UtenteController : ControllerBase
{
    private IUtenteDb _clienteDb;
    private IMapper _mapper;

    public UtenteController(IUtenteDb clienteDb, IMapper mapper)
    {
        _clienteDb = clienteDb;
        _mapper = mapper;
   
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UtentiDto>>> GetClientisAsync()
    {

        //IEnumerable<Utenti> clienti = await _clienteDb.GetAllAsync();

        //return Ok(clienti);

        IEnumerable<Utenti> clienti = await _clienteDb.GetAllAsync();
        var clientiDaStampare = _mapper.Map<IEnumerable<UtentiDto>>(clienti);
        return Ok(clientiDaStampare);
        //return Ok(clienti);
    }

    [HttpGet("{ClienteId}")]
    public async Task<ActionResult<UtentiDto>> GetClienteById(int ClienteId)
    {
        var Cliente = await _clienteDb.GetClienteByIdAsync(ClienteId);
        if (Cliente == null)
        {
            return BadRequest(new { error = "Non trovato" });
        }
        else
        {
            var clienteDto = _mapper.Map<UtentiDto>(Cliente);
            return Ok(clienteDto);
        }
    }

    [HttpGet("{bancaId}")]
    public async Task<ActionResult<Utenti>> GetClienteByIdBanca(int bancaId)
    {
        var Cliente = await _clienteDb.GetClienteByIdAsync(bancaId);
        if (Cliente == null)
        {
            return BadRequest("Non trovato");
        }
        else
        {
            return Ok(Cliente);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreaNuovoUtente([FromBody] UtentiDto nuovoUtente)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = "Invalid model state" });
            }

            if (string.IsNullOrWhiteSpace(nuovoUtente.NomeUtente) || string.IsNullOrWhiteSpace(nuovoUtente.Password))
            {
                return BadRequest(new { error = "Username e password non possono essere vuote" });
            }
            if (_clienteDb.IsUsernameUnique(nuovoUtente.NomeUtente))
            {
                return BadRequest(new { error = "Username esistente" });
            }
            if (!_clienteDb.BancaExists(nuovoUtente.IdBanca))
            {
                return BadRequest(new { error = $"La banca con ID {nuovoUtente.IdBanca} non esiste" });
            }
            var nuovoUtenteModels = _mapper.Map<Utenti>(nuovoUtente);
            nuovoUtenteModels.ContiCorrentes = new List<ContiCorrente> { new ContiCorrente { Saldo = 0 } };

            await _clienteDb.CreateUtenteAsync(nuovoUtenteModels);

            return CreatedAtAction("GetClienteById", new { ClienteId = nuovoUtenteModels.Id }, nuovoUtenteModels);

        }
        catch (Exception ex)
        {
            // Visualizza dettagli sull'errore interno
            return BadRequest(new { error = $"Errore Creando Utente: {ex.Message} - Dettagli: {ex.InnerException?.Message}" });
        }
    }



    [HttpPut("{ClienteId}")]
    public async Task<IActionResult> BloccaSbloccaUtente(int ClienteId, [FromBody] bool bloccato)
    {
        try
        {
            var utente = await _clienteDb.GetClienteByIdAsync(ClienteId);

            if (utente == null)
            {
                return NotFound(new { message = $"Utente con ID {ClienteId} non trovato" });
            }

            utente.Bloccato = bloccato;

            await _clienteDb.UpdateUtenteAsync(ClienteId, utente);

            return Ok(new { message = $"Stato blocco utente con ID {ClienteId} aggiornato con successo" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = $"Errore nell'aggiornamento dello stato blocco utente: {ex.Message}" });
        }
    }

    [HttpPut("aggiorna password/{ClienteId}")]
    public async Task<IActionResult> CambiaPassword(int ClienteId, [FromBody] string nuovaPassword)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(nuovaPassword))
            {
                return BadRequest("Username e password non possono essere vuote");
            }
            var utente = await _clienteDb.GetClienteByIdAsync(ClienteId);

            if (utente == null)
            {
                return NotFound($"Utente con ID {ClienteId} non trovato");
            }

            // Applica la nuova password
            utente.Password = nuovaPassword;

            await _clienteDb.UpdateUtenteAsync(ClienteId, utente);

            return Ok($"Password utente con ID {ClienteId} aggiornata con successo");
        }
        catch (Exception ex)
        {
            return BadRequest($"Errore nell'aggiornamento della password utente: {ex.Message}");
        }
    }

    [HttpDelete("{ClienteId}")]
    public async Task<IActionResult> EliminaUtente(int ClienteId)
    {
        try
        {
            await _clienteDb.DeleteUtenteAsync(ClienteId);

            return Ok(new { message = "Eliminazione Effettuata" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = $"Errore : {ex.Message}" });
        }
    }



}
