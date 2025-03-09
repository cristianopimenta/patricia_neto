
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("PagamentosPaciais")]
    public class PagarParcialModel
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("idContaPagar")]
        public ContaPagarModel ContaPagar { get; set; }
        
        public string NumeroDocumentoPagar { get; set; }= string.Empty;
        public string NumeroPedidoCompra { get; set; }= string.Empty;
        public int? OrdemDocumento { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Decimal ValorPagar { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Decimal ValorPagamentoParcial { get; set; }

        public DateTime? DataPagamentoParcial { get; set; }

        public string usuarioId { get; set; }= string.Empty;

    }
}
