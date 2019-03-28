using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesExercise.OCP
{
    interface IPricingRule
    {
        bool IsMatch(OrderItem item);
        decimal CalculateTotalPrice(OrderItem item);
    }
}
