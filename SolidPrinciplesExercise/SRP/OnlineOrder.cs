using System;

namespace SolidPrinciplesExercise.SRP
{
    public class OnlineOrder : Order, IPaymentProcesser, INotificationService, IReservationService
    {
        public void ProcessCreditCard(PaymentDetails details, Cart cart)
        {
            Console.WriteLine("Credit card processed");
        }
    }
}
