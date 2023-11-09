using AutoMapper;
using Bankomat.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Bankomat.Api.Repositories
{
    public class UtenteRepositoryDb : IUtenteDb
    {
        private BancomatV2Context _ctx;

        public UtenteRepositoryDb(BancomatV2Context bancomatV2Context)
        {
            _ctx = bancomatV2Context ?? throw new ArgumentNullException(nameof(bancomatV2Context));

        }
        public async Task<IEnumerable<Utenti>> GetAllAsync()
        {
            var Cliente = await _ctx.Utentis.ToListAsync();
            return Cliente;
        }

        public async Task CreateUtenteAsync(Utenti nuovoCliente)
        {

            _ctx.Utentis.Add(nuovoCliente);

            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteUtenteAsync(int ClienteId)
        {
            var cliente  = await _ctx.Utentis.FirstOrDefaultAsync(cliente => cliente.Id == ClienteId);

            if (cliente != null)
            {
                _ctx.Utentis.Remove(cliente); 
                await _ctx.SaveChangesAsync(); 
            }
            else
            {
                throw new Exception("Utente non trovato");
            }
        }


        public async Task<Utenti?> GetClienteByIdAsync(int ClienteId)
        {
            return await _ctx.Utentis
                .Where(cliente => cliente.Id == ClienteId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateUtenteAsync(int ClienteId, Utenti ClienteModificato)
        {
            var clienteSelezionato = await _ctx.Utentis.FirstOrDefaultAsync(cliente => cliente.Id == ClienteId);
            if (clienteSelezionato != null)
            {
                clienteSelezionato = ClienteModificato;

                await _ctx.SaveChangesAsync();
            }
        }

        public bool IsUsernameUnique(string username)
        {
            var utentiDb = _ctx.Utentis.Any(u => u.NomeUtente == username);

            if (utentiDb)
            {
                return true;
            }
            return false;
        }


        public bool BancaExists(long idBanca)
        {
            var bancheDb = _ctx.Banches.Any(b => b.Id == idBanca);
            if (bancheDb)
            {
                return true;
            }
            return false;
        }



    }
        
}

