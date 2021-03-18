using System;

namespace SolidPrinciplesExercise.OCP
{
    public class GetFiftyByWeightRule : IPricingRule
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
