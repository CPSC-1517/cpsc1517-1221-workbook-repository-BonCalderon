using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#region namepsaces for BLL and Entities
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion


namespace WestwindWebApp.Pages.Products
{
    public class QueryModel : PageModel
    {
        #region Setup constructor Dependency Injection for BLL
        private readonly CategoryServices _categoryServices;
        public QueryModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        #endregion

        #region Properties to populate Category select element and track its selected value
        public List<Category> CategoryList { get; private set; } //do not need empty list because we are going to populate it onGet
        
        [BindProperty] //bind the list of selected items
        public int SelectedCategoryId { get; set; }
        #endregion




        public void OnGet()
        {
            //Fetch from the system (CategoryServices)  a list of Category
            CategoryList = _categoryServices.List();

        }
    }
}
