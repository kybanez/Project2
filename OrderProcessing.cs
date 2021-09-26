using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class OrderProcessing
    {
        //uses OrerClass.cs
        private OrderClass OrderObject;
        private double TicketPrice;


        public OrderProcessing(OrderClass Torder, double price)
        {
            OrderObject = Torder;
            TicketPrice = price;
        }

        //Validate CC number
        private bool CCard(int cnumb)
        {
            if (cnumb >= 5000 && cnumb <= 7000)
                return true;
            else
                return false;
        }
        private double Tax = .12;
        private double LocationChange = .08;

        //
        private double ChargeStuff(int tickets, double unitPrice)
        {
            double total = (tickets * unitPrice) + Tax + LocationChange);
            return Tax * total + total;
        }

        public void POrder()
        {
            //CardNo variable is made in OderClass.cs
            if (CheckCreditCard(OrderObject.getCardNo))
            {
                double finalCharge = ChargeStuff(OrderObject.Amount, TicketPrice);
              //  Console.WriteLine ("Order from \n\tOrder Cost: {0}" , finalCharge);
                orderProcess(finalCharge); // sends confirmation to ticket broker
            }
            else
            {
                Console.WriteLine("Order from {0} has an invalid credit card number {1}", OrderObject.getSenderId, OrderObject.getCardNo);
            }
        }
    }
}
