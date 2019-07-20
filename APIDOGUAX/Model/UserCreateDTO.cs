using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDOGUAX.Model
{
    public class UserCreateDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve conter de 3 a 50 caracteres")]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email invalido.")]
        public string Email { get; set; }

    }
}
