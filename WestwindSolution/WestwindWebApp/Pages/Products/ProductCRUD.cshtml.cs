using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;

namespace WestwindWebApp.Pages.Products
{
    public class ProductCRUDModel : PageModel
    {
        #region internal fields
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        #endregion

        #region data properties for page
        [BindProperty(SupportsGet = true)]
        public int? EditProductId { get; set; }  

        #endregion



        public void OnGet()
        {
        }
    }
}
