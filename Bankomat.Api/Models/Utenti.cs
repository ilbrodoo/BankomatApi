using System;
using System.Collections.Generic;

namespace Bankomat.Api.Models
{
    public partial class Utenti
    {
        public Utenti()
        {
            ContiCorrentes = new HashSet<ContiCorrente>();
        }

        public long Id { get; set; }
        public long IdBanca { get; set; }
        public string NomeUtente { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Bloccato { get; set; }

        public virtual Banche IdBancaNavigation { get; set; } = null!;
        public virtual ICollection<ContiCorrente> ContiCorrentes { get; set; }
    }
}
