using System.ComponentModel.DataAnnotations;

namespace web.Data.Compras;

public class PedidoCompraModel
{
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int FornecedorId { get; set; }
        public FornecedorModel Fornecedor { get; set; }
        public List<PedidoItemModel> Itens { get; set; } = new List<PedidoItemModel>();
        public decimal Total { get; set; }
   
}

