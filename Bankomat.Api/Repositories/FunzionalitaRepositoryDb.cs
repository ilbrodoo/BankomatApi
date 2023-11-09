using Bankomat.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bankomat.Api.Repositories
{
    public class FunzionalitaRepositoryDb : IFunzionalitaDb
    {
        private BancomatV2Context _ctx;
        public FunzionalitaRepositoryDb(BancomatV2Context bancomatV2Context)
        {
            _ctx = bancomatV2Context ?? throw new ArgumentNullException(nameof(bancomatV2Context));
        }
        public async  Task<IEnumerable<Funzionalitum>> GetAllAsync()
        {
            return await _ctx.Funzionalita.ToListAsync();
        }

    }
}
