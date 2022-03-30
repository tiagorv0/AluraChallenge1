using System;
using System.ComponentModel.DataAnnotations;

namespace AluraChallenge1.DTO
{
    public class CreateVideoDTO
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public Uri Url { get; set; }
    }
}
