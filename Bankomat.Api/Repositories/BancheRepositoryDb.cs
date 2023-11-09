using Bankomat.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bankomat.Api.Repositories
{
    public class BancheRepositoryDb : IBancheDb
    {
        private BancomatV2Context _ctx;

        public BancheRepositoryDb(BancomatV2Context bancomatV2Context)
        {
            _ctx = bancomatV2Context ?? throw new ArgumentNullException(nameof(bancomatV2Context));
        }

          public async  Task<IEnumerable<Banche>> GetAllAsync()
        {
            var banca = await _ctx.Banches.ToListAsync();
            return banca;
        }

        public async Task<Banche?> GetBancaByIdAsync(long bancaId)
        {
            return await _ctx.Banches
              .Where(banche => banche.Id == bancaId)
              .FirstOrDefaultAsync();
        }

        
    }
}
