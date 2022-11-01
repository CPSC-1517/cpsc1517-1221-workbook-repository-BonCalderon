using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestwindWebApp.Pages.Categories
{
    public class ViewCategoryModel : PageModel
    {

        private readonly CategoryServices _categoryServices;

        public ViewCategoryModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public void OnGet()
        {
            Categories = _categoryServices.List();
        }
    }
}
