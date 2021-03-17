using System.Collections.Generic;
using GloomManager.Core.Enemy;
using GloomManager.Core.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GloomManager.Data.Services
{
    public class GloomManagerDbContext : IdentityDbContext<AppUser>
    {
        public GloomManagerDbContext(DbContextOptions<GloomManagerDbContext> options)
            : base(options)
        { }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<SpecialAbility> SpecialAbilities { get; set; }
        public DbSet<Stats> Stats { get; set; }
    }
}