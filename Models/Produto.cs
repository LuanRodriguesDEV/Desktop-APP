using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonowProject.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Valor { get; set; }
        public bool IsImprimir { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    
        //ToDo GerenciadorCombo
    }

}
