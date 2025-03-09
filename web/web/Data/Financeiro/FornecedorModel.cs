using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace web
{
    [Table("Fornecedores")]
    public class FornecedorModel
    {
        public FornecedorModel()
        {
            // Necessário para o EF Core
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do fornecedor não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres.")]
        public string CNPJ { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "O endereço não pode exceder 100 caracteres.")]
        public string Endereco { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "O telefone não pode exceder 50 caracteres.")]
        public string Telefone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "O email deve ser um endereço válido.")]
        public string Email { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "As observações não podem exceder 500 caracteres.")]
        public string Observacoes { get; set; } = string.Empty;


     
        public ICollection<ContaPagarModel> ContasPagar { get; set; } = new List<ContaPagarModel>();


    }

}