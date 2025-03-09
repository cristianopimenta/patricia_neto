using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("PessoaVeiculos")]
    public class PessoaVeiculo
    {
       
        public PessoaVeiculo(string cpfPessoa)
        {
            CpfPessoa = cpfPessoa;
        }

        [Key] public int Id { get; set; }
        public string CpfPessoa { get; set; }
        public string? Placa { get; set; }
        public string? MarcaModelo { get; set; }
        public string? Cor { get; set; }
        public string? IdUsuario { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;


    }
}
