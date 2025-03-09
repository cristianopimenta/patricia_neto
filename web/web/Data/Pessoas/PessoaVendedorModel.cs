using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace web
{
    [Table("PessoaVendedores")]
    public class PessoaVendedorModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Email { get; set; }= string.Empty;
        [Required, MaxLength(128)]
        public string Nome { get; set; }  = string.Empty;      
        public string Telefone { get; set; } = string.Empty;       
        public TipoPessoa tipoCliente { get; set; }
        public Sexo Sexo { get; set; }
        public string? CNPJ { get; set; }
        public string RG { get; set; }= string.Empty;

        [Required, Column(TypeName = "char(14)")]
        public string CPF { get; set; }= string.Empty;
        

        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataInativado { get; set; }
        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public int idade
        { get => (int)Math.Floor((DateTime.Now - DataNascimento).TotalDays / 365.2425); }

        public DateTime? DataSaida { get; set; }
        public double? PercentualComissao { get; set; }
        public double? LimiteLiberacao { get; set; }
       
        public TipoVendedor TipoVendedor { get; set; }
        

        public string? CodigoVendaSubstituiPedido { get; set; }

        public string? ChavePix { get; set; }
        public string? NomeBanco { get; set; }
        public string? Agencia { get; set; }
        public string? NumeroConta { get; set; }

        public string usuarioId { get; set; }= string.Empty;
        

        
    }
}
