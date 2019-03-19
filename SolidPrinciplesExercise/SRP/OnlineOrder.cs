using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
