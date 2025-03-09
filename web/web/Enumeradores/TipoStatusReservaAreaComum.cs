using System.ComponentModel;

namespace web
{
    public enum TipoStatusReservaAreaComum
    {
        [Description ("Liberado")] Liberado,
        [Description ("Reservado")] Reservado,
        [Description ("Limpeza")] Limpeza,
        [Description ("Reforma")] Reforma,
        [Description ("Danificado")] Danificado,
    }
}
