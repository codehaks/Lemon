using MediatR;
using Portal.Application.Foods.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.FoodApplication.Queries.FindAll
{
    public class FindAllFoodsQuery:IRequest<IList<FoodInfo>>
    {
    }
}
