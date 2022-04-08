using System;
using System.ComponentModel.DataAnnotations;

namespace AluraChallenge1.DTO
{
    public class UpdateVideoDTO
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public Uri Url { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public int CategoriaId { get; set; }
    }
}
