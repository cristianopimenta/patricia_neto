using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("PessoaContato")]
    public class PessoaContato
    {
        public PessoaContato() { }
        public PessoaContato(string cpfPessoa)
        {
            CpfPessoa = cpfPessoa;
        }

        [Key]
        public int Id { get; set; }
        public string CpfPessoa { get; set; }
        public string? Email { get; set; }
        public string? TipoContato { get; set; }
        public string? TelefoneCelular { get; set; }
        public string? TelefoneFixo { get; set; }
        public string? Ramal { get; set; }
        public string? Obervacao { get; set; }
        public bool? permiteAcessoToten { get; set; }
        public bool? AcessarSomenteLocalidade { get; set; }
        public string? CodigoAcesso { get; set; }
        public bool? ApresentarObservacoesTodosAcessos { get; set; }
        public string? ObservacaoSeguranca { get; set; }
        public string? IdUsuario { get; set; }
    }
}