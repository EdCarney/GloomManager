
namespace GloomManager.Web.Models
{
    public abstract class BaseEntityFormViewModel<T>
    {
        public int Id { get; set; }

        protected T Entity { get; set; }

        public bool IsUpdate => Id > 0;
    }
}