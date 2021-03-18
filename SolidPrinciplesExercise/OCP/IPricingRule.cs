namespace SolidPrinciplesExercise.OCP
{
    internal interface IPricingRule
    {
        bool IsMatch(OrderItem item);
        decimal CalculateTotalPrice(OrderItem item);
    }
}
