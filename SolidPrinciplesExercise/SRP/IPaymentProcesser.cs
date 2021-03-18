namespace SolidPrinciplesExercise.SRP
{
    public interface IPaymentProcesser
    {
        void ProcessCreditCard(PaymentDetails details, Cart cart);
    }
}
