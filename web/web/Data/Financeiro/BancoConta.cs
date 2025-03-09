using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("BancoContas")]
    public class BancoConta
    {

        [Key]
        public int Id { get; set; }
        public int IdBanco { get; set; }
        
        public string NomeConta { get; set; } = string.Empty;

        public string NumeroConta { get; set; }= string.Empty;
        public string DigitoConta { get; set; }= string.Empty;
        public string Agencia { get; set; }= string.Empty;
        public string? DigitoAgencia { get; set; }= string.Empty;

        public string GeraBoleto { get; set; }= string.Empty;
    }
}
