namespace Wikipedia.Models
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    public class Articol
    {
        public int Id { get; set; }
        public string Titlu { get; set; }
        public string Continut { get; set; }
        public string Autor { get; set; }
        public DateTime DataPublicare { get; set; }

        public int DomeniuId { get; set; }

        [ValidateNever]
        public Domeniu? Domenii { get; set; }


    }
}
