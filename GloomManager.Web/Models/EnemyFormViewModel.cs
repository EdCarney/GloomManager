
using GloomManager.Core;
using GloomManager.Web.Controllers;

namespace GloomManager.Web.Models
{
    public class EnemyFormViewModel : BaseEntityFormViewModel<Enemy>
    {
        public Enemy Enemy { get => Entity; set => Entity = value; }

        public string ActionName
        {
            get => IsUpdate ? nameof(EnemyController.Update) : nameof(EnemyController.Create);
        }

        public EnemyFormViewModel()
        {
            Enemy = new Enemy();
        }
    }
}