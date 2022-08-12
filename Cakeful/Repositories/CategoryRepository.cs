using Cakeful.Models;

namespace Cakeful.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CakefulDbContext _cakefulDbContext;

        public CategoryRepository(CakefulDbContext cakefulDbContext)
        {
            _cakefulDbContext = cakefulDbContext;
        }
        public IEnumerable<Category> GetCategories()
        {
            var categories = _cakefulDbContext.Categories;
            return categories;
        }
    }
}
