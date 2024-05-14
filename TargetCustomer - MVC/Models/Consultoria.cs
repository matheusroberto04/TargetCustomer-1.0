using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetCustomer___MVC.Models
{
    [Table("Tabela_Consultorias")]
    public class Consultoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        [Column("Nome_Do_Representante")]
        public string Representante { get; set; }
        [Required]

        [Column("Descricao_Consultoria")]
        public string DescricaoConsultoria { get; set; }
        [Required]

        [Column("Consultoria_Ativa")]
        public bool IsActive { get; set; } = true;

        public ICollection<AvaliacaoConsultoria>? Avalia { get; set; }
    }
}
