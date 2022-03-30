using System;

namespace AluraChallenge1.Models
{
    public class Video
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Uri Url { get; set; }
    }
}
