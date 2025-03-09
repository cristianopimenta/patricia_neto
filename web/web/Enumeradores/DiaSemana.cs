using System.ComponentModel;

namespace web
{
    public enum DiaSemana
    {
        [Description("Segunda")] Segunda,
        [Description("Terça")] Terca,
        [Description("Quarta")] Quarta,
        [Description("Quinta")] Quinta,
        [Description("Sexta")] Sexta,
        [Description("Sábado")] Sabado,
        [Description("Domingo")] Domingo,
        [Description("Segunda|Quarta|Sexta")] SQS,
        [Description("Terça|Quinta")] TQ,
        [Description("Sabado|Domingo")] SD,
        [Description("Todos os Diaso")] TodosDias,
        [Description("Quinzena")] Quinzena,
        [Description("Mês")] Mes,

    }
}
