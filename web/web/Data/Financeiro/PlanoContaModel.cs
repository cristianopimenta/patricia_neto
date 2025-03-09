using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace web
{
    [Table("PlanoContas")]
    public class PlanoContaModel
    {
        [Key]
        public int Id { get; set; }

        public string? CodigoPlanoContas {  get; set; }
       
        public string? Descricao {  get; set; }= string.Empty;
        

        [NotMapped]
        public TipoPlano? TipoPlanos { get; set; }

        public string? usuarioId { get; set; }= string.Empty;

        public ICollection<FornecedorModel> Fornecedores { get; set; } = new List<FornecedorModel>();
        public ICollection<PessoaModel> Pessoas { get; set; } = new List<PessoaModel>();
    }
    
}
