using System.ComponentModel.DataAnnotations;

namespace backend.Models.ViewModels
{
    public class AccountViewModel
    {
        public Account Account { get; set; }
        public Account ToAccount { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Range(0, 10000, ErrorMessage = "{0} deve estar entre {1} e {2}")]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }

        public string Action { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public int SendToAccount { get; set; }
    }
}
