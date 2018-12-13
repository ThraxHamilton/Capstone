using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Cons
    {
        [Key]
        public int ConId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string ConEntry { get; set; }
    }
}
