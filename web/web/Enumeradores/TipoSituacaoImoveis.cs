using System.ComponentModel;

namespace web
{
    public enum TipoSituacaoImoveis
    {
        [Description("Habilitado")] Habilitado,
        [Description("Não Habilitado")] NaoHabilitado,
        [Description("Obra Definitiva")] ObraDefinitiva,
        [Description("Obra Parada")] ObraParada,
        [Description("Terreno")] Terreno,
        [Description("Mureta")] Mureta,
        [Description("Obra Provisoria")] ObraProvisioria,
        [Description("Habilitado/Em Reforma")] HabilitadoEmReforma,
        [Description("Obra Bloqueada")] ObraBloqueada,
        [Description("Não Habilitado/Em Reforma")] NaoHabilitadoEmReforma,

    }
}
