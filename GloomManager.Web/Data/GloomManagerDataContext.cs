using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GloomManager.Core;

    public class GloomManagerDataContext : DbContext
    {
        public GloomManagerDataContext (DbContextOptions<GloomManagerDataContext> options)
            : base(options)
        {
        }

        public DbSet<GloomManager.Core.Enemy> Enemy { get; set; }
    }
