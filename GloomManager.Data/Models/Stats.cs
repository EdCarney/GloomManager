using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloomManager.Data.Models
{
    class Stats
    {
        [Display(Name = "Health")]
        [Range(1, 50)]
        public int TotalHealth { get; set; }

        [Display(Name = "Base Movement")]
        [Range(1, 50)]
        public int BaseMovement { get; set; }

        [Display(Name = "Base Attack")]
        [Range(1, 50)]
        public int BaseAttack { get; set; }

        [Display(Name = "Base Range")]
        [Range(1, 50)]
        public int BaseRange { get; set; }
    }
}
