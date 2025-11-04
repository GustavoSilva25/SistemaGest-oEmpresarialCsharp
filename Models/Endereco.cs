using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaDeCadastroEmp.Models;

namespace SistemaDeCadastroEmp.Models
{
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEndereco { get; set; }

        [Required, StringLength(200)]
        public string Rua { get; set; }
        // 0 ate 10 digitos
        [Range(0, 9999999999)]
        public int Numero { get; set; }
        [Required, StringLength(100)]
        public string Bairro { get; set; }
        [Required, StringLength(100)]
        public string Cidade { get; set; }
        [Required, StringLength(2)]
        public string Estado { get; set; }
        [Required, StringLength(45)]
        public string Cep { get; set; }

        public int IdEmpresa { get; set; }

        [ ForeignKey("IdEmpresa")]
        public Empresa empresa { get; set; }

    }
}