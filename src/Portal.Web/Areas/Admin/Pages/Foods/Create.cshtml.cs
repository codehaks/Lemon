using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Application.Foods;
using Portal.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Portal.Web.Areas.Admin.Pages.Foods
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IFoodService _foodService;
        public CreateModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [Range(0, int.MaxValue)]
        [Required]
        public int PriceAmount { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [Required]
        public FoodType FoodType { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _foodService.Create(new Application.Foods.Models.FoodAddInfo
            {
                Price = PriceAmount,
                Description = Description,
                FoodType = FoodType,
                Name = Name
            });



            TempData["message"] = "New food created";
            return RedirectToPage("./index");


        }
    }
}