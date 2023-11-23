using Bankomat.Api.Dto;
using Bankomat.Api.Models;

namespace Bankomat.Api.Repositories
{
    public interface IFunzionalitaDb
    {
        Task<IEnumerable<Funzionalitum>> GetAllAsync();
    }
}
