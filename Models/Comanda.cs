using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonowProject.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int Mesa { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Desconto { get; set; }
        public bool Estado { get; set; }
        public DateTime Abertura { get; set; }
        public int CaixaId { get; set; }
        public Nullable<DateTime> Fechamento { get; set; }
    }

}
