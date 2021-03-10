using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloomManager.Core.Enemy
{
    public class SpecialAbility : EntityBase
    {
        [Column(TypeName = "VARCHAR(150)")]
        public string Description { get; set; }
    }
}