using MediatR;
using Portal.Application.Foods.Models;
using Portal.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.FoodApplication.Queries.FindAll
{
    public class FindAllFoodsQuery:IRequest<IList<FoodInfo>>
    {
        public FoodType FoodType { get; set; }
    }
}
