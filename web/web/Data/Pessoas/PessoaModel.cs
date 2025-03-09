using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{

    [Table("pessoa")]
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }
        public string? EmailPrincipal { get; set; }
        public string? TelefonePrincipal { get; set; }


        public string? CpfPessoa { get; set; }

        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        public string? DataNascimento { get; set; }

        public string? Sexo { get; set; }

        public string? Apelido { get; set; }

        public string? Mae { get; set; }

        public string? Pai { get; set; }

        public string? ApresentaMensagemEntrada { get; set; }

        public string? Mensagem { get; set; }

        public string? ObsSeguranca { get; set; }

        public int? IdCNH { get; set; }

        public int? IdUsuarioAtendente { get; set; }

        public string? Tipo { get; set; }

        public string? TipoCadastro { get; set; }
        public string? TipoCategoria { get; set; }
        public string? Parentesco { get; set; }

        public bool? QrCodeGerado { get; set; }

        public string? TipoImovel { get; set; }

        public string? TipoMorador { get; set; }
        public string? IdUsuario { get; set; }

        public ICollection<ContaReceberModel> ContasReceber { get; set; } = new List<ContaReceberModel>();
    }
}
