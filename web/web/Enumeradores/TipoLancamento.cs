using System.ComponentModel;

namespace web.Enumeradores
{
    public enum TipoLancamento
    {
        [Description("Contas a Receber")] Receber,
        [Description("Contas a Pagar")] Pagar,
    }
}
