using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesExercise.OCP
{
    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<IPricingRule> pricingRules;
        
        public PricingCalculator()
        {
            pricingRules = new List<IPricingRule>
            {
                new B4GoRule(),
                new BoGoRule(),
                new GetFiftyByWeightRule()
            };
        }

        public decimal CalculatePrice(OrderItem item)
        {
            return pricingRules.First(r => r.IsMatch(item)).CalculateTotalPrice(item);
        } 
    }
}
