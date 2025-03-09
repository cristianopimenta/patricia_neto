using System.ComponentModel;

namespace web.Enumeradores
{
    public enum TipoPortaria
    {
        [Description("Serviço")] servico,
        [Description("Social")] social,
        [Description("Clube")] clube,
        [Description("Pilates")] pilates,
        [Description("Academia")] academia,
        
    }
}
