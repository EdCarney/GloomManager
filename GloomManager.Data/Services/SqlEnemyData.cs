using System;
using System.Collections.Generic;
using System.Linq;
using GloomManager.Core;
using Microsoft.EntityFrameworkCore;

namespace GloomManager.Data.Services
{
    public class SqlEnemyData : IEnemyManager
    {
        private readonly GloomManagerDbContext db;
        private readonly DbSet<Enemy> table;

        public SqlEnemyData(GloomManagerDbContext db)
        {
            this.db = db;
            table = db.Enemies;
        }
        public int Add(Enemy entity)
        {
            table.Add(entity);
            return SaveChanges();
        }

        public int AddRange(IEnumerable<Enemy> entities)
        {
            table.AddRange(entities);
            return SaveChanges();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            return Delete(new Enemy { Id = id, Timestamp = timeStamp });
        }

        public int Delete(Enemy entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return Save(entity);
        }

        public IEnumerable<Enemy> GetAll()
        {
            return table.ToList();
        }

        public IEnumerable<Enemy> GetEnemiesByName(string name)
        {
            return from e in table
                   where e.Name.ToLower().Contains(name.ToLower())
                   select e;
        }

        public Enemy GetEnemyByNameElitenessLevel(string name, EnemyEliteness eliteness, int level)
        {
            return (from e in table
                   where e.Name.ToLower().Contains(name.ToLower())
                   && e.Eliteness == eliteness
                   && e.Level == level
                   select e).SingleOrDefault();
        }

        public Enemy GetOne(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<Enemy> GetUniqueEnemies()
        {
            return from e in table
                   where e.Level == 0
                   && e.Eliteness == EnemyEliteness.Standard
                   select e;
        }

        public IEnumerable<Enemy> GetUniqueEnemiesByName(string name)
        {
            return from e in table
                   where e.Level == 0
                   && e.Eliteness == EnemyEliteness.Standard
                   && e.Name.ToLower().Contains(name.ToLower())
                   select e;
        }

        public int Save(Enemy entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        private int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}