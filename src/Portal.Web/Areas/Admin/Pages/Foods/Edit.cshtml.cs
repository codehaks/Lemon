using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Application.Foods;
using Portal.Common.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Web.Areas.Admin.Pages.Foods
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IFoodService _foodService;
        public EditModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public int Id { get; set; }
        public int PriceAmount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FoodTypeName { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var food = await _foodService.GetEdit(id);

            Id = food.Id;
            PriceAmount = food.Price;
            Name = food.Name;
            Description = food.Description;
            FoodTypeName = food.FoodType.Name;
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            
            await _foodService.Update(new Application.Foods.Models.FoodEditInfo()
            {
                Id = Id,
                Name = Name,
                Price = PriceAmount,
                Description = Description,
                FoodType = Domain.Common.Enumeration.GetAll<FoodType>().Single(f=>f.Name==FoodTypeName)
            });

            return RedirectToPage("./Index");


        }


    }
}