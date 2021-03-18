namespace SolidPrinciplesExercise.OCP
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}
