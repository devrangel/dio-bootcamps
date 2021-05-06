using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve ser entre {2} e {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public string TipoConta { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Range(0, 1000000, ErrorMessage = "{0} deve estar entre {1} e {2}")]
        [DataType(DataType.Currency)]
        public double Saldo { get; set; }

        public Account()
        {

        }

        public Account(string nome, string tipoConta, double saldo)
        {
            Nome = nome;
            TipoConta = tipoConta;
            Saldo = saldo;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo < valorSaque)
            {
                return false;
            }
            else
            {
                this.Saldo -= valorSaque;
                return true;
            }
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
        }

        public void Transferir(double valorTransferencia, Account contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
    }
}
