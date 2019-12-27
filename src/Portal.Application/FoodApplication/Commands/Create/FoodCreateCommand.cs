using MediatR;
using Portal.Application.Foods.Models;
using Portal.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.FoodApplication.Commands.Create
{
    public class FoodCreateCommand:IRequest<FoodCreateCommandResult>
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}
