using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomManager.Data.Models
{
    class Enemy : EntityBase
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

        [Display(Name = "Special Abilities")]
        public List<string> SpecialAbilities { get; set; } = new List<string>();
    }
}
