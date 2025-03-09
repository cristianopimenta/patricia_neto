using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace web
{

    [Table("PessoasEnderecos")]
    public class PessoaEndereco
    {
        public PessoaEndereco() { }
        public PessoaEndereco(string cpfPessoa)
        {
            CpfPessoa = cpfPessoa;
        }

        [Key]
        public int Id { get; set; }
        public string CpfPessoa { get; set; }

        public int ImovelId { get; set; }
        public ImovelModel Imovel { get; set; }
        public DateTime DataEndereco { get; set; } = DateTime.Now;
        public string? IdUsuario { get; set; }

    }
}