using System.ComponentModel.DataAnnotations;

namespace MonowProject.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Senha { get; set; }



    }
}
