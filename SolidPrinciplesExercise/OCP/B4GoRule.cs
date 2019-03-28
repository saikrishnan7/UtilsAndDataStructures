using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesExercise.OCP
{
    public class B4GoRule : IPricingRule
    {
        public decimal CalculateTotalPrice(OrderItem item)
        {
            throw new NotImplementedException();
        }

        public bool IsMatch(OrderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
