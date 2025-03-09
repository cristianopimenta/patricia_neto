using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{

    [Table("PanicoMobile")]
    public class PanicoMobile
    {
        [Key]
        public int Id { get; set; }
        public string idPessoa { get; set; }
        public string DescricaoAlerta { get; set; }
        public string? DataAlerta { get; set; }
        public string? DataAtendimento { get; set; }
        public string? StatusAlerta { get; set; }
        public string? TipoEmergencia { get; set; }
        public string? IdUsuarioAtendimento { get; set; }

    }
}