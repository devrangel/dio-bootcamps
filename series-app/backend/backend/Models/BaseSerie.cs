using System.ComponentModel.DataAnnotations;

namespace backend.Models.Interfaces
{
    public abstract class BaseSerie
    {
        [Key]
        public int Id { get; set; }
    }
}
