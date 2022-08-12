using Cakeful.Models;

namespace Cakeful.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }
}
