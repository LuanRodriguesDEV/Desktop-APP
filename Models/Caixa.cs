using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonowProject.Models
{
    public class Caixa
    {
        [Key]
        public int Id { get; set; } = default!;
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal SaldoInicial { get; set; }


        [Column(TypeName = "decimal(5,2)")]
        public Nullable<decimal> SaldoFinalEmDinheiro { get; set; }


        [Column(TypeName = "decimal(5,2)")]

        public Nullable<decimal> SaldoFinalEmCartoes { get; set; }

        public DateTime DataAbertura { get; set; }
        public Nullable<DateTime> DataFechamento { get; set; }

        //ToDo Vincular Funcionario 


    }
}
