using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDOGUAX.Model
{
    public class AdressCreateDTO
    {
        [Required(ErrorMessage = "O campo RUA é obrigatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve conter de 3 a 50 caracteres")]
        public string Street { get; set; }
        [Required(ErrorMessage = "O campo Bairro é obrigatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve conter de 3 a 50 caracteres")]
        public string District { get; set; }
    }
}
