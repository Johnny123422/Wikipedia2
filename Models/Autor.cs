namespace Wikipedia.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public List<Articol> Articole { get; set; }
    }
}
