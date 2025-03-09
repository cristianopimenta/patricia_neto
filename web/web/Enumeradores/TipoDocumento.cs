using System.ComponentModel;

namespace web
{
    public enum TipoDocumento
    {
        [Description("RG")] RG,
        [Description("CNH")] CNH,
        [Description("Registro Internacional")] RegistroInternacional,
    }
}
