using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            this.OrderObject = Torder;
            this.TicketPrice = price;
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
            double total = ((tickets * unitPrice) + Tax + LocationChange);
            return Tax * total + total;
        }

        public void POrder()
        {
            if(OrderObject !=null )
            {
                Console.WriteLine("Processing Order {0} from TicketBroker {1}", Thread.CurrentThread.Name, OrderObject.ToString());
                //CardNo variable is made in OderClass.cs
                if (CCard(OrderObject.CardNum))
                {
                    Console.WriteLine("Validating {0} Credit Card Number Valid", Thread.CurrentThread.Name);
                    //double finalCharge = ChargeStuff(OrderObject.Amount, TicketPrice);
                    //  Console.WriteLine ("Order from \n\tOrder Cost: {0}" , finalCharge);
                    // orderProcess(finalCharge); // sends confirmation to ticket broker
                }
                else
                {
                    Console.WriteLine("Error {0} Credit Card Number not Valid ", Thread.CurrentThread.Name);
                }

                Console.WriteLine("Processing {0} TicketBroker {1} \n TOTAL PRICE: {2}",
                    Thread.CurrentThread.Name, OrderObject.ToString(), ChargeStuff(OrderObject.Quantity, TicketPrice).ToString());
            }
            else
            {
                Console.WriteLine("Processing {0} order not received", Thread.CurrentThread.Name);
            }

          
        }
    }
}