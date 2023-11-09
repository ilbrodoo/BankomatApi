using System;
using System.Collections.Generic;

namespace Bankomat.Api.Models
{
    public partial class Banche
    {
        public Banche()
        {
            BancheFunzionalita = new HashSet<BancheFunzionalitum>();
            Utentis = new HashSet<Utenti>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<BancheFunzionalitum> BancheFunzionalita { get; set; }
        public virtual ICollection<Utenti> Utentis { get; set; }
    }
}
