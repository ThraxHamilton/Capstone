using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels
{
    public class ProConViewModel
    {
        public Pros Pros { get; set; }

        public Cons Cons { get; set; }

        public string Date { get; set; }
        public string ProEntry { get; set; }
        public string ConEntry { get; set; }


    }
}
