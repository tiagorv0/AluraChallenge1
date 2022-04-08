using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AluraChallenge1.DTO
{
    public class ListVideoCategoriaDTO
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Cor { get; set; }

        public List<UpdateVideoDTO> Videos { get; set; }

    }
}
