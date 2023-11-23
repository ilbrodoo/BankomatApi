namespace Bankomat.Api.Dto
{
    public class UtentiDto
    {
       public long Id { get; set; }
        public long IdBanca { get; set; }
        public string NomeUtente { get; set; } = null!;
        public string Password { get; set; } = null!;

        public bool Bloccato { get; set; }  
    }
}
