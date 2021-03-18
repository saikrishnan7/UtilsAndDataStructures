using System.Collections.Generic;
using System.Linq;

namespace SolidPrinciplesExercise.OCP
{
    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<IPricingRule> _pricingRules;
        
        public PricingCalculator()
        {
            _pricingRules = new List<IPricingRule>
            {
                new B4GoRule(),
                new BoGoRule(),
                new GetFiftyByWeightRule()
            };
        }

        public decimal CalculatePrice(OrderItem item)
        {
            return _pricingRules.First(r => r.IsMatch(item)).CalculateTotalPrice(item);
        } 
    }
}
