using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeCadastroEmp.Models
{
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }
        [Required, StringLength(200)]
        public string RazaoSocial { get; set; }
        [Required, StringLength(200)]
        public string NomeFantasia { get; set; }
        [Required, StringLength(14)]
        public string CNPJ { get; set; }
        [Required, StringLength(200)]
        public string AreaAtuacao { get; set; }

        public Endereco endereco { get; set; }

        public Contato contato { get; set; }

    }
}

