using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{

    [Table("Enderecos")]
    public class EnderecoModel
    {
        [Key]
        public int Id { get; set; }
        public int? ClienteId { get; set; }

       
        public string? Logradouro { get; set; }

        
        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        
        public string? Bairro { get; set; }

        
        public string? Cidade { get; set; }

        [Column(TypeName = "char(2)")]
        public string? Estado { get; set; }

        [Column(TypeName = "char(9)")]
        public string? CEP { get; set; }

        public string? Referencia { get; set; }

        public bool? Selecionado { get; set; }

        [NotMapped]
        public string EnderecoCompleto
        {
            get
            {
                return $"{Logradouro}, {Numero} {Complemento}, {Bairro}, {Cidade}, {Estado}, CEP {CEP}";
            }
        }

    }

}
