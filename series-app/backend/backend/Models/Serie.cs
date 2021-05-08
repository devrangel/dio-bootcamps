using backend.Models.Enum;
using backend.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Serie : BaseSerie
    {
        [Required]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(140, MinimumLength = 1, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
        public string Descricao { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy")]
        public int Ano { get; set; }

        public Serie(Genero genero, string titulo, string descricao, int ano)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
        }
    }
}
