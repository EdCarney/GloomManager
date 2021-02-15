﻿using GloomManager.Core;
using GloomManager.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomManager.Data.Services
{
    public interface IEnemyManager : IRepo<Enemy>
    {
        IEnumerable<Enemy> SearchName(string name);
    }
}
