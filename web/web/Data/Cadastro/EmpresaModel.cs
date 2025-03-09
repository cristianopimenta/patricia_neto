using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace web
{

    [Table("Empresas")]
    public class EmpresaModel
    {
        public EmpresaModel()
        {
            // Necessário para o EF Core
        }
        public EmpresaModel(string cnpj)
        {
            CNPJ = cnpj ?? throw new ArgumentNullException(nameof(cnpj), "O CNPJ não pode ser nulo.");
        }

        [Key] public int Id { get; set; }

        public string TipoCondominio { get; set; }

        public string? Email { get; set; } = string.Empty;
        [Required] public string? NomeResponsavel { get; set; }

        public string? RazaoSocial { get; set; } = string.Empty;
        [Required] public string NomeFantasia { get; set; } = string.Empty;

        public string? TelefonePrincipal { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido.")]
        public string? CNPJ { get; set; }

         public string? CEP { get; set; }
         public string? Endereco { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Observacao { get; set; }

        public bool? Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAbertura { get; set; }
        public DateTime? HabiteseCondominio { get; set; }
        public DateTime? HabitesePrefeitura { get; set; }      

        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? UrlMapaRastreio { get; set; }
        public string? Descricao { get; set; }
        public string? UsuarioId { get; set; }

    }
}