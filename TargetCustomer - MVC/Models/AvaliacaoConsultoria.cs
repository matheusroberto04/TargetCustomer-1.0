using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetCustomer___MVC.Models
{
    [Table("Tabela_AvaliacaoConsultoria")]
    public class AvaliacaoConsultoria
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]

        public Usuario Usuario { get; set; }

        [Column("TextoAvaliacao")]
        public required string TextoAvaliacao { get; set; }

        public int ConsultoriaID { get; set; }
        [ForeignKey("ConsultoriaID")]
        public Consultoria Consultoria { get; set; }
    }
}
    

