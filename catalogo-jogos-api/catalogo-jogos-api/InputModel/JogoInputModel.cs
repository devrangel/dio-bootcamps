using System;
using System.ComponentModel.DataAnnotations;

namespace catalogo_jogos_api.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da produtora deve conter entre {2} e {1} caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "O preço do jogo deve ser no mínimo {1} real e no máximo {2} reais")]
        public double Preco { get; set; }
    }
}
