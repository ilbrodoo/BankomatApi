using System;
using System.Collections.Generic;

namespace Bankomat.Api.Models
{
    public partial class Funzionalitum
    {
        public Funzionalitum()
        {
            BancheFunzionalita = new HashSet<BancheFunzionalitum>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<BancheFunzionalitum> BancheFunzionalita { get; set; }
    }
}
