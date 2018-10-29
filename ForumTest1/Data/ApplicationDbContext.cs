using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ForumTest1.Models;

namespace ForumTest1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
