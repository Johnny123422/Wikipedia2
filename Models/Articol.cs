using Wikipedia.Models;

public class Articol
{
    public int Id { get; set; }
    public string Titlu { get; set; }
    public string Continut { get; set; }

    public int DomeniuId { get; set; }
    public Domeniu Domeniu { get; set; }

    public int AutorId { get; set; }
    public Autor Autor { get; set; }

    public List<Comentariu> Comentarii { get; set; }
}
