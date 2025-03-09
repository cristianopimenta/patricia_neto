using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace web
{
    [Table("tipo_perfil")]
    public class TipoPerfilModel
    {
        [Key]
        public uint id { get; set; } // unsigned int mapeado como uint
        public string nome { get; set; } = null!; // varchar(45), obrigatório


    }
}