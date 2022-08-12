using Cakeful.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cakeful.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetCategories().OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
