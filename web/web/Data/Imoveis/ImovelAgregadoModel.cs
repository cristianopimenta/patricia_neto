using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("ImovelAgregado")]
    public class ImovelAgregadoModel
    {
        [Key]
        public int Id { get; set; }
        public string? quadra { get; set; }
        public string? lote { get; set; }
        public string? logradouro { get; set; }
        public string? area { get; set; }
        public string? sala { get; set; }
        public string? andar { get; set; }
        public string? apartamento { get; set; }
        public string? observacao { get; set; }
        public bool? ativo { get; set; } = true;
        public int? IdUsuario { get; set; }
    }
}
