using System;
using System.Collections.Generic;

namespace Bankomat.Api.Models
{
    public partial class Movimenti
    {
        public long Id { get; set; }
        public string NomeBanca { get; set; } = null!;
        public string NomeUtente { get; set; } = null!;
        public string Funzionalita { get; set; } = null!;
        public int Quantita { get; set; }
        public DateTime DataOperazione { get; set; }
    }
}
