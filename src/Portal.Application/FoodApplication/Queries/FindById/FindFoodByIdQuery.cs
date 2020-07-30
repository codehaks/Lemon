using MediatR;
using Portal.Application.Foods.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.FoodApplication.Queries.FindById
{
    public class FindFoodByIdQuery:IRequest<FoodInfo>
    {
        public int Id { get; set; }
    }
}
