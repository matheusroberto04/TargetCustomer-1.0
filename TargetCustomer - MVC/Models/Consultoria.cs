using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetCustomer___MVC.Models
{
    [Table("Consultorias")]
    public class Consultoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]

        [Column("Nome_Do_Representante")]
        public string Representante { get; set; }
        [Required]

        [Column("Descricao_Consultoria")]
        public string DescricaoConsultoria { get; set; }
        [Required]

        [Column("Consultoria_Ativa")]
        public bool IsAtive { get; set; } = true;
    }
}
