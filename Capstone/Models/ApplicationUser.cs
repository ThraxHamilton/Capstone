using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string AppUsername { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Pros> Pros { get; set; }
        public virtual ICollection<Cons> Cons { get; set; }
    }
}
