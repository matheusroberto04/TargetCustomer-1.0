using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetCustomer___MVC.Models
{
    [Table("AvaliacaoConsultoria")]
    public class AvaliacaoConsultoria
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]

        [Column("TextoAvaliacao")]
        public required string TextoAvaliacao { get; set; }
        

    }
}
    

