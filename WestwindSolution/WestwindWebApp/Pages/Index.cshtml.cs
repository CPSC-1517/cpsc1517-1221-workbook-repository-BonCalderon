using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region custom namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WestwindWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly BuildVersionServices _buildVersionServices;
        public IndexModel(ILogger<IndexModel> logger, BuildVersionServices buildVersionServices) // constructor dependency injection
        {
            _logger = logger;
            _buildVersionServices = buildVersionServices;
        }

        public BuildVersion CurrentBuildVersion { get; set; } = null!;
        public void OnGet() //everytime there is onGet request , its gonna fetchh buildversion
        {
            CurrentBuildVersion = _buildVersionServices.GetBuildVersion();
        }
    }
}