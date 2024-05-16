using System.ComponentModel.DataAnnotations;

namespace TargetCustomer___MVC.DTOs
{
    public class AvaliacaoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Usuario { get; set;}
        [Required]
        public string TextoAvaliacao { get; set;}
    }
}
