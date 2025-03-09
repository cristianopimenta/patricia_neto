using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace web
{
    [Table("Condominios")]
    public class CondominioModel
    {
        public CondominioModel() { }
        public CondominioModel(string cnpj, string usuarioIdMestre)
        {
            CNPJ = cnpj;
            UsuarioIdMestre = usuarioIdMestre;
        }

        [Key]
        public int Id { get; set; }

        [Required] [StringLength(14)] public string CNPJ { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; } = DateTime.UtcNow;
        public DateTime? DataAbertura { get; set; }

        public TipoImovel tipoImovel { get; set; }

        //Parametrizacao
        public bool? ExibirCampoFilipeta { get; set; }
        public bool? HabilitarListaFerramentasPrestador { get; set; }
        public bool? UsarDigitosCPFFilipeta { get; set; }
        public bool? UsarPlacaFilipeta { get; set; }
        public bool? BotoeiraVirtual { get; set; }
        public bool? PossuiControleFacial { get; set; }
        public bool? PossuirControleQRCode { get; set; }
        public bool? ImovelAlugadoPermiteEntradaAssociado { get; set; }
        public bool? ImovelAlugadoPermiteAssociadoFalaLiberacao { get; set; }

        //cadastros
        public bool? GerarCodigoAutomaticoPermanente { get; set; }
        public bool? CondominioPossuiAcademia { get; set; }
        public bool? CondominioPossuiAcademiaIntegracaoFinanceiro { get; set; }
        public bool? CondominioAcademiaExigiAtestadoMedico { get; set; }
        public bool? CondominioAcademiaPermiteAcessoPermanentes { get; set; }
        public bool? CondominioPossuiPilates { get; set; }
        public bool? CondominioPossuiPilatesIntegracaoFinanceiro { get; set; }
        public bool? CondominioPossuiGPS { get; set; }

        //padroes liberação
        public string? VisitantesHorarioPermitidoLiberacaoDas { get; set; }
        public string? VisitantesHorarioPermitidoLiberacaoAs { get; set; }
        public string? VisitantesTempoMaximoLibTemporarias { get; set; }

        public string? PrestadoresHorarioPermitidoLiberacaoDas { get; set; }
        public string? PrestadoresHorarioPermitidoLiberacaoAs { get; set; }
        public string? PrestadoresTempoMaximoLibTemporarias { get; set; }
        public string? ClubeTempoMaximoLibTemporarias { get; set; }
        public bool? ExigirCNHObrigatorio { get; set; }
        public bool? PermitirCNHVencida { get; set; }
        public bool? ExigirPlacaObrigatorio { get; set; }
        public bool? HabilitarCameraDocumento { get; set; }
        public bool? HabilitarEntradaSaidaTempTerminais { get; set; }
        public bool? VisitanteExigirCampoTelefoneEntrada { get; set; }
        public bool? VisitanteExigirCampoNascimentoEntrada { get; set; }
        public bool? VisitanteExigirCampoMaeEntrada { get; set; }
        public bool? VisitanteExigirCampoCNHEntrada { get; set; }
        public bool? PrestadorExigirCampoTelefoneEntrada { get; set; }
        public bool? PrestadorExigirCampoNascimentoEntrada { get; set; }
        public bool? PrestadorExigirCampoMaeEntrada { get; set; }
        public bool? PrestadorExigirCampoCNHEntrada { get; set; }

        //perfil

        public bool? HabilitarRegistroAtividadesMoradores { get; set; }

        //panico
        public string Instrucao_um { get; set; }
        public string Instrucao_dois { get; set; }
        public string Instrucao_tres { get; set; }
        
        public string UsuarioIdMestre { get; set; }


    }
}

