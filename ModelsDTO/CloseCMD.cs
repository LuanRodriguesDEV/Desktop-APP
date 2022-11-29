using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonowProject.ModelsDTO
{
    public class CloseCMD
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Desconto { get; set; }

     
   
    }
}
