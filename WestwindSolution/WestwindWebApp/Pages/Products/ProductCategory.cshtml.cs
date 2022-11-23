using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

#region namepsaces for BLL and Entities
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WestwindWebApp.Pages.Products
{
    public class ProductCategoryModel : PageModel
    {
        #region Setup constructor DI for BLL
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;

        public ProductCategoryModel(CategoryServices categoryServices, ProductServices productServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;

            // Fetch from the system (CategoryServices) a list of Category
            List<Category> categories = _categoryServices.List();
            CategorySelectList = new SelectList(categories, "Id", "CategoryName", SelectedCategoryId); //populate dropdown selection menu

        }
        #endregion

        #region Properties to populate Category select element and track is selected value
        //public List<Category> CategoryList { get; private set; }

        //Data source for category select element
        public SelectList CategorySelectList { get; private set; }
        
        [BindProperty] //bindable property for value selected from select element 
        public int? SelectedCategoryId { get; set; }
        
        //query result list propery
        public List<Product>? QueryProductResultList { get; private set; }
        #endregion

        //[BindProperty]
        //public string? QueryProductName { get; set; }

        //feedback message property
        
        public string? InfoMessage { get; set; }
        public string? ErrorMessage { get; set; }

       

        public void OnGet()
        {

        }

        public IActionResult OnPostFetchProducts()
        {
            IActionResult nextPage = Page();
            // verify that a valid category was selected
            if (SelectedCategoryId.HasValue && SelectedCategoryId.Value > 0)
            {
                int categoryId = SelectedCategoryId.Value;
                QueryProductResultList = _productServices.FindProductsByCategoryId(categoryId);
                InfoMessage = $"Query Returned {QueryProductResultList.Count} record(s).";
            }
            else
            {
                ErrorMessage = "A valid category must be selected";
            }
          
            return nextPage;
        }


        public IActionResult OnPostClear()
        {
            IActionResult nextPage = Page();
            SelectedCategoryId = null;
            QueryProductResultList = null;
            ModelState.Clear();


            return nextPage;
        }

        public IActionResult OnPostNewProduct()
        {
            IActionResult nextPage = RedirectToPage("/Products/ProductCRUD"); // inside the redirect page is the route you want it to redirect to. Razor pages access a route not a file name , do not inlcude file extension

            return nextPage;
        }
   
    }
}
