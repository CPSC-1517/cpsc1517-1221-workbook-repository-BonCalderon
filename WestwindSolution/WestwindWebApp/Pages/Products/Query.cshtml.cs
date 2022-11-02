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
        
        [BindProperty()] //bind the list of selected items use of asp-for inside cshtml
        public int SelectedCategoryId { get; set; }
        public SelectList CategorySelectList { get; private set; }
        #endregion
        public string FeedBackMessage { get; private set; }



        public void OnGet(int? currentSelectedCategoryId)
        {

            //Fetch from the system (CategoryServices)  a list of Category
            CategoryList = _categoryServices.List();
            CategorySelectList = new SelectList(_categoryServices.List(),"Id","CategoryName",4); //selectedcategory value sets the default
           
            if (currentSelectedCategoryId.HasValue && currentSelectedCategoryId.Value > 0)
            {
                SelectedCategoryId = currentSelectedCategoryId.Value;
            }
        }

        public IActionResult OnPostSearchByCategory() //make sure capital O and P for On Post
        {
            FeedBackMessage = "You click on Search by Category";
            return RedirectToPage(new { currentSelectedCategoryId = SelectedCategoryId });
        }

        public IActionResult OnPostSearchByProductName()
        {
            FeedBackMessage = "You click on Search by Product Name";
            return RedirectToPage();
        }

        public IActionResult OnPostClearForm()
        {
            FeedBackMessage = "You click to Clear Form";
            return RedirectToPage();
        }
    }
}
