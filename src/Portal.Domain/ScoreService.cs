using Portal.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
    public class ScoreService
    {
        public int CalculateScore(Order order,ApplicationUser user)
        {
            // user register
            return order.Items.Count * 10;
        }
    }
}
