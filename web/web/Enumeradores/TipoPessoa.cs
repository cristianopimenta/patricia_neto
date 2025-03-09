using System.ComponentModel;

namespace web
{
    public enum TipoPessoa
    {
        [Description("Associado")] Associado,
        [Description("Morador")] Morador,
        [Description("Inquilino")] Inquilino,
        [Description("Preposto")] Preposto,
        [Description("Prestador")] Prestador,
    }
}
