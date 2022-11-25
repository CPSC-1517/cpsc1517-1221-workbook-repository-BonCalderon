using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WestwindSystem.Entities;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestwindWebApp.Pages.Products
{
    public class ProductCRUDModel : PageModel
    {
        #region internal fields
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;
        #endregion

        #region data properties for page
        [BindProperty(SupportsGet = true)] //if this page is accessed it will automatically find a route EditProductId and if it findes it it sets it in this property
        public int? EditProductId { get; set; }
        //Data source for category select element
        public SelectList CategorySelectList { get; private set; }

        public SelectList SupplierSelectList { get; private set; }

        [BindProperty] //bindable property for value selected from select element 
        public int? SelectedCategoryId { get; set; }

        [BindProperty]
        public int? SelectedSupplierId { get; set; }

        //The Current Product to add, update, or delete.
        [BindProperty]
        public Product CurrentProduct { get; set; }

        public string InfoMessage { get; set; }
        public string ErrorMessage { get; set; }


        #endregion

        #region constructor with dependecies
        public ProductCRUDModel (CategoryServices categoryServices, ProductServices productServices, SupplierServices supplierServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;
            _supplierServices = supplierServices;

            
            List<Category> categories = _categoryServices.List();
            CategorySelectList = new SelectList(categories, "Id", "CategoryName", SelectedCategoryId);

            List<Supplier> suppliers = _supplierServices.List();
            SupplierSelectList = new SelectList(suppliers, "SupplierId", "SelectListText");




        }
        #endregion

        #region page handlers
        public void OnGet()
        {
            if (EditProductId != null)
            {
                int productId = EditProductId.Value;
                var querySingleResult = _productServices.GetById(productId);
                if (querySingleResult != null)
                {
                    CurrentProduct = querySingleResult;
                }
                else
                {
                    ErrorMessage = $"Invalid product id of {EditProductId}";
                }
               
            }
        }

        #endregion



    }
}
