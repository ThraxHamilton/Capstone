using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Pros
    {
        [Key]
        public int ProId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        [Required]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string ProEntry { get; set;  }


    }
}
