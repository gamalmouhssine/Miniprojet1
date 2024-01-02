using Microsoft.EntityFrameworkCore;
using Miniprojet.Shared.Entites;
using System;
using System.Reflection;

namespace Miniprojet.Server.AppDbcontext
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
      
    }
}
