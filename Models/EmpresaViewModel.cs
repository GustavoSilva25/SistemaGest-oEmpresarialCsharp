
using System.ComponentModel.DataAnnotations;

public class EmpresaViewModel
{
        // Empresa
        [ScaffoldColumn(false)] // deixa oculto na view
        public int? IdEmpresa { get; set; }

        [Required(ErrorMessage = "A razão social é obrigatória.")]
        [StringLength(200, ErrorMessage = "A razão social deve ter no máximo 200 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O nome fantasia é obrigatório.")]
        [StringLength(200, ErrorMessage = "O nome fantasia deve ter no máximo 200 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter exatamente 14 dígitos numéricos.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "A área de atuação é obrigatória.")]
        [StringLength(200, ErrorMessage = "A área de atuação deve ter no máximo 200 caracteres.")]
        public string AreaAtuacao { get; set; }

        // Contato

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "Formato de telefone inválido.")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres.")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string email { get; set; }

        // Endereço
        [Required(ErrorMessage = "A rua é obrigatória.")]
        [StringLength(200, ErrorMessage = "A rua deve ter no máximo 200 caracteres.")]
        public string Rua { get; set; }

        [Range(0, 9999999999, ErrorMessage = "O número deve ter entre 0 e 10 dígitos.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "Use apenas a sigla do estado, com 2 letras.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000.")]
        public string Cep { get; set; }

}