
using Bankomat.Api.Models;

namespace Bankomat.Api.Repositories
{
    public interface IUtenteDb
    {
        Task<IEnumerable<Utenti >> GetAllAsync();   
        Task<Utenti> GetClienteByIdAsync(int ClienteId);
      
        Task UpdateUtenteAsync(int ClienteId, Utenti ClienteModificato);

         Task DeleteUtenteAsync(int ClienteId);

         Task CreateUtenteAsync(Utenti nuovoCliente);
        public bool IsUsernameUnique(string username);
        public bool BancaExists(long idBanca);


    }
}
