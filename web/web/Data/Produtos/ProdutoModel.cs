using System.ComponentModel.DataAnnotations;

namespace web.Data.Produtos;

public class ProdutoModel
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public int FornecedorId { get; set; }
    public FornecedorModel Fornecedor { get; set; }
}