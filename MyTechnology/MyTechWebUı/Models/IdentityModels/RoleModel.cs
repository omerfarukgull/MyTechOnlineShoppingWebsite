using Microsoft.Build.Framework;
using System.ComponentModel;

namespace MyTechWebUı.Models.Identity
{
    public class RoleModel
    {
        [Required]
        [DisplayName("Rol Adı")]
        public string Name { get; set; }
    }
}
