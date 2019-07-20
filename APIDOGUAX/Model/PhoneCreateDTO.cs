using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDOGUAX.Model
{
    public class PhoneCreateDTO
    {
        [Required(ErrorMessage = "O campo DDD é obrigatorio.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo deve conter de 2 a 2 caracteres")]
        public string Ddd { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatorio.")]
        [StringLength(123, MinimumLength = 9, ErrorMessage = "O campo deve conter de 9 a 12 caracteres")]
        public string Number { get; set; }
    }
}
