using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Blog.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext( DbContextOptions <AppDBContext> options ) : base (options)
        {

        }
        public DbSet <Post> Posts { get; set; }
    }
}
