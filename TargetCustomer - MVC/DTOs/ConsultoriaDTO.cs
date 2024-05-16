using System.ComponentModel.DataAnnotations;

namespace TargetCustomer___MVC.DTOs
{
    public class ConsultoriaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Representante { get; set; }
        [Required]
        public string DescricaoConsultoria { get; set; }
    }
}
