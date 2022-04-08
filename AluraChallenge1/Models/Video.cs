using System;
using System.Text.Json.Serialization;

namespace AluraChallenge1.Models
{
    public class Video : Base
    {
        public string Descricao { get; set; }
        public Uri Url { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
    }
}
