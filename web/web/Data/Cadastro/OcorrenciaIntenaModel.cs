using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("OcorrenciaInterna")]
    public class OcorrenciaInternaModel
    {
        [Key]
        public int Id { get; set; }
        public int? IdPessoa { get; set; }

        public int? IdImovel { get; set; }
        public string? descricao { get; set; }
        public string? atividade { get; set; }
        public DateTime? concluirDia { get; set; }
        public DateTime? dataCadastro { get; set; } = DateTime.Now;
        public string? hora { get; set; }
        public string? status { get; set; }
        public int? IdUsuario { get; set; }
    }
}
