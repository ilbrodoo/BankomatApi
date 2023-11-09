using System;
using System.Collections.Generic;

namespace Bankomat.Api.Models
{
    public partial class ContiCorrente
    {
        public long Id { get; set; }
        public long IdUtente { get; set; }
        public int Saldo { get; set; }
        public DateTime DataUltimaOperazione { get; set; }
        public DateTime? DataUltimoVersamento { get; set; }

        public virtual Utenti IdUtenteNavigation { get; set; } = null!;
    }
}
