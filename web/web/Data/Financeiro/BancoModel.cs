using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("Bancos")]
    public class BancoModel
    {
       
        public int Id { get; set; }
        public string NomeBanco { get; set; }= string.Empty;
        public int NumeroBanco { get; set; }

    }
}
