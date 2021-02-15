using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GloomManager.Web.Models
{
    public class EnemyViewModel
    {
        public StatsViewModel Stats { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 10)]
        public int Level { get; set; }

        [Required]
        public string Eliteness { get; set; }

        [Display(Name = "Special Abilities")]
        public List<string> SpecialAbilities { get; set; }
    }
}
