using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        
        [BindProperty] //bind the list of selected items use of asp-for inside cshtml
        public int SelectedCategoryId { get; set; }
        public SelectList CategorySelectList { get; private set; }
        #endregion




        public void OnGet()
        {
            //Fetch from the system (CategoryServices)  a list of Category
            CategoryList = _categoryServices.List();
            CategorySelectList = new SelectList(_categoryServices.List(),"Id","CategoryName",SelectedCategoryId); //slected category value is passed so you do not need to use asp-for

        }

        public void OnPostSearchByCategory() //make sure capital O and P for On Post
        {

        }

        public void OnPostSearchByProductName()
        {

        }

        public void OnPostClearForm()
        {

        }
    }
}
