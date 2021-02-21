using System.Collections.Generic;
using GloomManager.Core;
using Microsoft.EntityFrameworkCore;

namespace GloomManager.Data.Services
{
    public class GloomManagerDbContext : DbContext
    {
        public GloomManagerDbContext(DbContextOptions<GloomManagerDbContext> options)
            : base(options)
        { }
        public DbSet<Enemy> Enemies { get; set; }
    }
}