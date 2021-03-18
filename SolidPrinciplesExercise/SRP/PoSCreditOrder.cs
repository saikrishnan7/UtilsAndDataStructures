using System;

namespace SolidPrinciplesExercise.SRP
{
    public class PoSCreditOrder : IPaymentProcesser
    {
        protected Cart Cart { get; set; }

        public void ProcessCreditCard(PaymentDetails details, Cart cart)
        {
            Console.WriteLine("Credit card processed");
        }

        protected void CheckOut()
        {
            Console.WriteLine("CheckOut Complete");
        }
    }
}
