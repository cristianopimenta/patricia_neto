using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("Localidade")]
    public class LocalidadeModel
    {
        [Key]
        public int Id { get; set; }        
        public string? descricao { get; set; } 
        public string? latitude { get; set; }
        public string? longitude {  get; set; }
        public string? urlMapaRastreio { get; set; }
        public bool? cadastrado { get; set; }
        public DateTime? dataCadastro { get; set; } = DateTime.Now;
        public DateTime? dataModificacaoRegistro { get; set; } = DateTime.Now;
        public bool? ativo { get; set; } = true;
        public int? IdUsuario { get; set; }
    }
}
