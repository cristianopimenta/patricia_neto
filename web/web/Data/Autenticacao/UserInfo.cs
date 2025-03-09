using System.ComponentModel.DataAnnotations;

namespace web.Data.Autenticacao
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }



    }
}
