using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowerWeb_APP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string SearchType { get; set; }  
        public string SearchTerm { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string searchType, string searchTerm)
        {
            SearchType = searchType;
            SearchTerm = searchTerm;
        }
    }
}