using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
        {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

        public DbSet<WebApplication1.Models.ApplicationRole> ApplicationRole { get; set; }
        
        public DbSet<WebApplication1.Models.ApplicationUser> ApplicationUser { get; set; }


    }


}
