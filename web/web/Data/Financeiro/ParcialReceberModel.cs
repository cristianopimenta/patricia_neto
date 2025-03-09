
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("RecebimentosPaciais")]
    public class ParcialReceberModel
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("idContaReceber")]
        public ContaReceberModel ContaReceber { get; set; }
      
        public string NumeroDocumentoReceber { get; set; }= string.Empty;
        public string NumeroPedidoVenda { get; set; }= string.Empty;
        public int? OrdemDocumento { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Decimal ValorReceber { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Decimal ValorRecebimentoParcial { get; set; }

        public DateTime? DataRecebimentoParcial { get; set; }

        public string usuarioId { get; set; }= string.Empty;
    }
}
