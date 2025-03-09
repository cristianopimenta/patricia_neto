using System.ComponentModel;

namespace web
{
    public enum Sexo
    {
        [Description("Masculino")] Masculino,
        [Description("Feminino")] Feminino,
        [Description("NaoInformado")] NaoInformado,
    }
}
