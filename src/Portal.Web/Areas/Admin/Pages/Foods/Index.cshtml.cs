using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Portal.Application.Foods;
using Portal.Application.Foods.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portal.Web.Areas.Admin.Pages.Foods
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly IFoodService _foodService;

        public IndexModel(IFoodService foodService, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _foodService = foodService;
        }

        public IList<FoodInfo> FoodList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            _logger.LogInformation("Foods Index");
            FoodList = await _foodService.FindAll();
            return Page();
        }
    }
}