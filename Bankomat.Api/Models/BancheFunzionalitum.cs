using System;
using System.Collections.Generic;

namespace Bankomat.Api.Models
{
    public partial class BancheFunzionalitum
    {
        public long Id { get; set; }
        public long IdBanca { get; set; }
        public long IdFunzionalita { get; set; }

        public virtual Banche IdBancaNavigation { get; set; } = null!;
        public virtual Funzionalitum IdFunzionalitaNavigation { get; set; } = null!;
    }
}
