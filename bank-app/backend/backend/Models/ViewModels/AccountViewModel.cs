using System.ComponentModel.DataAnnotations;

namespace backend.Models.ViewModels
{
    public class AccountViewModel
    {
        public Account Account { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Range(0, 10000, ErrorMessage = "{0} deve estar entre {1} e {2}")]
        [DataType(DataType.Currency)]
        public double ValorSaque { get; set; }
    }
}
