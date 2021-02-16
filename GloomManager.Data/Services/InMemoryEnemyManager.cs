using GloomManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomManager.Data.Services
{
    public class InMemoryEnemyManager : IEnemyManager
    {
        private List<Enemy> enemies;

        public InMemoryEnemyManager()
        {
            #region Local Enemy Definition
            enemies = new List<Enemy>
            {
                new Enemy
                {
                    Id = 1, Name = "Bandit Archer", Eliteness = EnemyEliteness.Standard, Level = 0,
                    BaseStats = new Stats { TotalHealth = 4, BaseAttack = 2, BaseMovement = 2, BaseRange = 3 },
                    SpecialAbilities = new List<string>(),
                    Type = EnemyType.Archer
                },
                new Enemy
                {
                    Id = 2, Name = "Bandit Archer", Eliteness = EnemyEliteness.Elite, Level = 0,
                    BaseStats = new Stats { TotalHealth = 6, BaseAttack = 3, BaseMovement = 2, BaseRange = 3 },
                    SpecialAbilities = new List<string>(),
                    Type = EnemyType.Archer
                },
                new Enemy
                {
                    Id = 3, Name = "Bandit Archer", Eliteness = EnemyEliteness.Standard, Level = 1,
                    BaseStats = new Stats { TotalHealth = 5, BaseAttack = 2, BaseMovement = 2, BaseRange = 4 },
                    SpecialAbilities = new List<string>(),
                    Type = EnemyType.Archer
                },
                new Enemy
                {
                    Id = 4, Name = "Bandit Archer", Eliteness = EnemyEliteness.Elite, Level = 1,
                    BaseStats = new Stats { TotalHealth = 7, BaseAttack = 3, BaseMovement = 2, BaseRange = 5 },
                    SpecialAbilities = new List<string>(),
                    Type = EnemyType.Archer
                },
                new Enemy
                {
                    Id = 5, Name = "Living Bones", Eliteness = EnemyEliteness.Standard, Level = 0,
                    BaseStats = new Stats { TotalHealth = 3, BaseAttack = 1, BaseMovement = 2 },
                    SpecialAbilities = new List<string> { "Can target two enemies" },
                    Type = EnemyType.Undead
                },
                new Enemy
                {
                    Id = 6, Name = "Living Bones", Eliteness = EnemyEliteness.Elite, Level = 0,
                    BaseStats = new Stats { TotalHealth = 6, BaseAttack = 2, BaseMovement = 4 },
                    SpecialAbilities = new List<string> { "Can target two enemies" },
                    Type = EnemyType.Undead
                },
                new Enemy
                {
                    Id = 7, Name = "Living Bones", Eliteness = EnemyEliteness.Standard, Level = 1,
                    BaseStats = new Stats { TotalHealth = 5, BaseAttack = 1, BaseMovement = 3 },
                    SpecialAbilities = new List<string> { "Can target two enemies" },
                    Type = EnemyType.Undead
                },
                new Enemy
                {
                    Id = 8, Name = "Living Bones", Eliteness = EnemyEliteness.Elite, Level = 1,
                    BaseStats = new Stats { TotalHealth = 6, BaseAttack = 2, BaseMovement = 4 },
                    SpecialAbilities = new List<string> { "Can target three enemies", "Shield 1" },
                    Type = EnemyType.Undead
                }
            };
            #endregion
        }
        public int Add(Enemy entity)
        {
            entity.Id = enemies.Max(e => e.Id) + 1;
            enemies.Add(entity);
            return Save(entity);
        }

        public int AddRange(IEnumerable<Enemy> entities)
        {
            foreach (var e in entities)
                Add(e);
            return entities.Count();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            return Delete(new Enemy { Id = id, Timestamp = timeStamp });
        }

        public int Delete(Enemy entity)
        {
            enemies.Remove(entity);
            return Save(entity);
        }

        public IEnumerable<Enemy> GetAll()
        {
            return enemies.OrderBy(e => e.Name);
        }

        public Enemy GetOne(int id)
        {
            return enemies.SingleOrDefault(e => e.Id == id);
        }

        public int Save(Enemy entity)
        {
            return 1;
        }

        public IEnumerable<Enemy> GetEnemiesByName(string name)
        {
            if (name is null)
                return null;
            return from e in enemies
                   where e.Name.ToLower().Contains(name.ToLower())
                   orderby e.Name
                   select e;
        }

        public Enemy GetEnemyByNameElitenessLevel(string name, EnemyEliteness eliteness, int level)
        {
            if (name is null || level < 0)
                return null;
            return (from e in enemies
                    where e.Name.ToLower().Contains(name.ToLower())
                    && e.Eliteness == eliteness
                    && e.Level == level
                    select e).SingleOrDefault();
        }

        public IEnumerable<Enemy> GetUniqueEnemies()
        {
            return from e in enemies
                   where e.Level == 0
                   && e.Eliteness == EnemyEliteness.Standard
                   select e;
        }

        public IEnumerable<Enemy> GetUniqueEnemiesByName(string name)
        {
            var uniqueEnemies = GetUniqueEnemies();
            return from e in uniqueEnemies
                   where e.Name.ToLower().Contains(name.ToLower())
                   select e;
        }
    }
}
