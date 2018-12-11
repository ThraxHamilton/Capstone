using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
    
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Pros> Pros { get; set; }
        public DbSet<Cons> Cons { get; set; }

    }
}
