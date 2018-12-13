using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels
{
    public class ProConViewModel
    {
        public List<Pros> GetPros { get; set; }
        public Pros Pros { get; set; }

        public ProConViewModel() { }
        public ProConViewModel(List<Pros> pros)
        {

            GetPros = pros.Select(li => new Pros
            {
                Date = li.Date,
                ProEntry = li.ProEntry
              
            }).ToList();
        }

        public Cons Cons { get; set; }

        public string Date { get; set; }
        public string ProEntry { get; set; }
        public string ConEntry { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}
