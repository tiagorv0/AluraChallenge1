using System.Collections.Generic;

namespace AluraChallenge1.Models
{
    public class Categoria : Base
    {
        public string Cor { get; set; }
        public virtual List<Video> Videos { get; set; }
    }
}
