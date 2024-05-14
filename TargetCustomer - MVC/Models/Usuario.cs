using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetCustomer___MVC.Models
{
    [Table("Tabela_Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Nome_Usuario")]
        public string Nome { get; set; }
        [Required]
        [Column("CNPJ")]
        public int CNPJ { get; set; }
        [Required]
        [Column("Razao_Social")]
        public string Razao { get; set; }
        [Required]
        [Column("Telefone")]
        public int Telefone { get; set; }
        [Required]
        [Column("Ramo_De_Atuacao")]
        public string RamoDeAtuacao { get; set; }
        [Required]
        [EmailAddress]
        [Column("Email")]
        public string Email { get; set; }
        [Required]

        [Column("Logradouro")]
        public string Logradouro { get; set; }
        [Required]
        [Column("Numero_Logradouro")]
        public int NumeroLogradouro { get; set; }
        [Required]
        [Column("Senha")]
        public string HashSenha { get; set; }

        [Column("Usuario_Ativo")]
        public bool IsActive { get; set; } = true;

        public ICollection<AvaliacaoConsultoria>? Avalia { get; set; }
        public ICollection<Consultoria>? Consulta { get; set; }
    }
}
