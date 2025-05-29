namespace Wikipedia.Models
{
    public class Comentariu
    {
        public int Id { get; set; }
        public string Continut { get; set; }

        public int ArticolId { get; set; }
        public Articol Articol { get; set; }
    }
}
