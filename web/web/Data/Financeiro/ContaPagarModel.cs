
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Controller.Interface;
using web.Enumeradores;


namespace web
{
    [Table("ContasPagar")]
    public class ContaPagarModel : IConta
    {
        [Key]
        public int Id { get; set; }
        
        public int? FornecedorId { get; set; }    
        public FornecedorModel? Fornecedor { get; set; }    
      
        public int? PlanoContaId { get; set; }
        public PlanoContaModel PlanoConta { get; set; }
        public string NumeroDocumento { get; set; }= string.Empty;
        public string DescricaoDocumento { get; set; }= string.Empty;        
        
        [Column(TypeName = "decimal(18,4)")]
        public Decimal ValorPagamento {  get; set; }  
        public DateTime? DataDocumento { get; set; }
        public DateTime? DataVencimento {  get; set; }       
        public DateTime? DataPagamento { get; set; }
        public double? JurosMulta { get; set; }
        public double? JurosMora { get; set; }
        public double? Desconto {  get; set; }
        public string? Observacoes { get; set; }= string.Empty;
        public TipoLiquidacao StatusConta { get; set; } = TipoLiquidacao.Pendente;
        public string? TipoFatura { get; set; }
        public DateTime? DataSistema { get; set; } = DateTime.UtcNow;
        public Moeda CodigoMoeda { get; set; } = Moeda.BRL;

        public string? usuarioId { get; set; }= string.Empty;

        public decimal Valor => ValorPagamento;
    }
}
