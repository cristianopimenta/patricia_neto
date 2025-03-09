using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace web
{
    [Table("PessoaDocumentos")]
    public class PessoaDocumento
    {
        public PessoaDocumento(string cpfPessoa)
        {
            this.CpfPessoa = cpfPessoa;
        }

        [Key]
        public int Id { get; set; }
        public String CpfPessoa { get; set; } 
        public string? documento { get; set; }= string.Empty;
        public TipoDocumento tipoDocumento { get; set; }
        public DateTime? dataRegistroDocumento { get; set; } 
        public DateTime? dataVencimentoDocumento { get; set; }
        public string? OrgaoResponsavel { get; set; }
        public bool? ativo { get; set; } = true;
        public string? IdUsuario { get; set; }
     

    }
}
