using GloomManager.Data.Models;
using GloomManager.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomManager.Data.Services
{
    interface IEnemyManager : IRepo<Enemy>
    {
        IEnumerable<Enemy> SearchName(string name);
    }
}
