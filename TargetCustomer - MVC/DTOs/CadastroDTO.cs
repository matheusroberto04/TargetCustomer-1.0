using System.ComponentModel.DataAnnotations;

namespace TargetCustomer___MVC.DTOs
{
    public class CadastroDTO
    {
        [Required]
        public int CNPJ { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        public int Telefone { get; set; }

        [Required]
        public string RamodeAtuacao { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int NumeroLogradouro { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string SenhaHash { get; set; }

    }
}
