using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomManager.Core
{
    public class Stats
    {
        [Range(1, 50)]
        public int TotalHealth { get; set; }

        [Range(1, 50)]
        public int BaseMovement { get; set; }

        [Range(1, 50)]
        public int BaseAttack { get; set; }

        [Range(1, 50)]
        public int BaseRange { get; set; }
    }
}
