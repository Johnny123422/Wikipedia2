﻿namespace Wikipedia.Models
{
    public class Domeniu
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public List<Articol> Articole { get; set; }
    }
}
