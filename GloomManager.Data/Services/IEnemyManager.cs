using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloomManager.Core.Enemy;
using GloomManager.Data.Repos;

namespace GloomManager.Data.Services
{
    public interface IEnemyManager : IRepo<Enemy>
    {
        IEnumerable<Enemy> GetEnemiesByName(string name);
        IEnumerable<Enemy> GetUniqueEnemies();
        IEnumerable<Enemy> GetUniqueEnemiesByName(string name);
        Enemy GetEnemyByNameElitenessLevel(string name, EnemyEliteness eliteness, int level);
    }
}
