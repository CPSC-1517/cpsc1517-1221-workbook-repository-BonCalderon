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
        [BindProperty(SupportsGet = true)] //if this page is accessed it will automatically find a route EditProductId and if it findes it it sets it in this property
        public int? EditProductId { get; set; }
        #endregion

        #region constructor with dependecies

        #endregion

        #region page handlers

        #endregion



        public void OnGet()
        {
        }
    }
}
