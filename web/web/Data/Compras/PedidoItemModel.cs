using System.ComponentModel.DataAnnotations;
using web.Data.Produtos;

namespace web.Data.Compras;

public class PedidoItemModel
{
        [Key]
        public int Id { get; set; }
        public int PedidoCompraId { get; set; }
        public PedidoCompraModel PedidoCompra { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }

       

        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    
}