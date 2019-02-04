using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Identity.Models
{
    public class User : IdentityUser
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(60)]
        [Required]
        public string Surname { get; set; }
    }
}
