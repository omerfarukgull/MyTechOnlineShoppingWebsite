using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyTechWebUı.Models.Identity
{
    public class LoginModel
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string Password { get; set; }
    }
}
