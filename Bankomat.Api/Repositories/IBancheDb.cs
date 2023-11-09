using Bankomat.Api.Models;

namespace Bankomat.Api.Repositories
{
    public interface IBancheDb
    {
        Task<IEnumerable<Banche>> GetAllAsync();
        Task<Banche> GetBancaByIdAsync(long bancaId);

    }
}
