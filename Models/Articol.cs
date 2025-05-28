namespace Wikipedia.Models
{
    public class Articol
    {
        public int Id { get; set; }
        public string Titlu { get; set; }
        public string Continut { get; set; }
        public string Autor { get; set; }
        public DateTime DataPublicare { get; set; }

        public int DomeniuId { get; set; }

        public Domeniu? Domenii { get; set; } 


    }
}
