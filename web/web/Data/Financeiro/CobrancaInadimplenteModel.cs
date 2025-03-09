using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("CobrancaInadimplentes")]
    public class CobrancaInadimplenteModel
    {
        [Key]
        public int Id { get; set; }
        public int IdPlanoContas { get; set; }
        public int IdPessoa { get; set; }
        public int IdImovel { get; set; }

        public int IdModulo { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataInclusão { get; set; }

        public int DiasAtraso { get; set; }

    }
}
