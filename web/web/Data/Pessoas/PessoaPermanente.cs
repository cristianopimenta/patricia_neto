using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("PessoasPermanentes")]

    public class PessoaPermanente
    {
        [Key] 
        public int id { get; set; } // id
        public int? id_pessoa { get; set; } // id_pessoa
        public string? codigo { get; set; } // codigo
        public string? pai { get; set; } // pai
        public string? nacionalidade { get; set; } // nacionalidade
        public string? naturalidade { get; set; } // naturalidade
        public string? profissao { get; set; } // profissao
        public string? email { get; set; } // email
        public string? ativo { get; set; } // ativo
        public int? id_imovel { get; set; } // id_imovel
        public string? ultima_atualizacao { get; set; } // ultima_atualizacao
        public string? tipo { get; set; } // tipo
        public string? senha { get; set; } // senha
        public string? grau_parentesco { get; set; } // grau_parentesco
        public string? permitir_liberacao { get; set; } // permitir_liberacao
        public string? associado { get; set; } // associado
        public string? chefe_imediato { get; set; } // chefe_imediato
        public int? id_empresa { get; set; } // id_empresa
        public DateTime? data_vencimento { get; set; } // data_vencimento
        public string? categoria { get; set; } // categoria
        public string? tipo_servico { get; set; } // tipo_servico
        public string? permitir_cad_permanente { get; set; } // permitir_cad_permanente
        public string? permitir_acesso_toten { get; set; } // permitir_acesso_toten
        public string? acesso_somente_sua_localidade { get; set; } // acesso_somente_sua_localidade
        public int? id_pessoa_autorizante { get; set; } // id_pessoa_autorizante
        public int? id_endereco { get; set; } // id_endereco
        public string? end_secundario_correspondencia { get; set; } // end_secundario_correspondencia
        public string? email_alternativo { get; set; } // email_alternativo
        public DateTime? modificado_em { get; set; } // modificado_em
        public string? morador_prestador { get; set; } // morador_prestador
        public string? especialidade { get; set; } // especialidade
        public bool? permitir_acesso_historico { get; set; } // permitir_acesso_historico

    }
}