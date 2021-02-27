
using System.Collections.Generic;
using GloomManager.Web.Controllers;
using GloomManager.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GloomManager.Web.Models
{
    public class EnemyFormViewModel : BaseEntityFormViewModel<Enemy>
    {
        public Enemy Enemy { get => Entity; set => Entity = value; }

        // public string ActionName
        // {
        //     get => IsUpdate ? nameof(EnemyController.Update) : nameof(EnemyController.Create);
        // }

        public IEnumerable<SelectListItem> EnemyElitenessesOptions { get; set; }

        public IEnumerable<SelectListItem> EnemyTypeOptions { get; set; }

        public EnemyFormViewModel()
        {
            Enemy = new Enemy();
        }
    }
}