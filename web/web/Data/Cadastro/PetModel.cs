using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web
{
    [Table("Pets")]
    public class PetModel
    {
        [Key]
        public int Id { get; set; }
        public int? IdPessoa {  get; set; }
        public string? nome { get; set; } 
        public string? raca { get; set; }
        public string? porte {  get; set; }
        public DateTime? datanascimento { get; set; }
        public bool? cadastrado { get; set; }
        public bool? ativo { get; set; } = true;
        public int? idCartaoVacina {  get; set; }
        public string? tipo { get; set; }
    }
}
