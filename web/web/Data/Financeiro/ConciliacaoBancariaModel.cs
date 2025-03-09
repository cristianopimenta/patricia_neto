using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Data.Financeiro
{
 
    [Table("ConciliacaoBancaria")]
    public class ConciliacaoBancariaModel
    {
        public ConciliacaoBancariaModel()
        {
            DataConciliacao = DateTime.Now;
            DataLancamentoBanco = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("ContaPagarId")]
        public ContaPagarModel? ContaPagar { get; set; }
        public int? ContaPagarId { get; set; }

        [ForeignKey("ContaReceberId")]
        public ContaReceberModel? ContaReceber { get; set; }
        public int? ContaReceberId { get; set; }

        public DateTime DataConciliacao { get; set; }
        public decimal ValorConciliado { get; set; }

        public string Banco { get; set; } = string.Empty;
        public string NumeroDocumentoBanco { get; set; } = string.Empty;
        public DateTime DataLancamentoBanco { get; set; }
        public decimal ValorBanco { get; set; }
        public bool Conciliado { get; set; } = false;

        public string usuarioId { get; set; } = string.Empty;
    }
}
