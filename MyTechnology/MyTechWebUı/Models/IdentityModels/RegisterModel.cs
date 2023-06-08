using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyTechWebUı.Models.Identity
{
    public class RegisterModel
    {
        [Required]
        [DisplayName("İsim")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Soyisim")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Şifre")]
        public string RePassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Adresiniz")]
        public string Email { get; set; }
    }
}
