using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.VO
{
    public class LivroVO :  ISupportHyperMedia
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        
        public string Editora { get; set; }
 
        public decimal Preco { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
