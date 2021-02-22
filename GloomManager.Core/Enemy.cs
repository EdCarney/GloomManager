using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomManager.Core
{
    public class Enemy : EntityBase
    {
        public Stats BaseStats { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 10)]
        public int Level { get; set; }

        [Required]
        public EnemyEliteness Eliteness { get; set; }

        [Required]
        public EnemyType Type { get; set; }

        public List<SpecialAbility> SpecialAbilities { get; set; }
    }
}
