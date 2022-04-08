using System.ComponentModel.DataAnnotations;

namespace AluraChallenge1.DTO
{
    public class UpdateCategoriaDTO
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Cor { get; set; }
    }
}
