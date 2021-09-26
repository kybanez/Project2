using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    //uses OrerClass.cs
      private OrderClass OrderObject;
      private double TicketPrice;


      public OrderProcessing(OrderClass Torder, double price)
     {
         OrderObject = Torder;
         TicketPrice = price;
     }

     private bool CCard(int cnumb)
      {
        if ( cnumb >= 5000 && ncumb <= 7000)
          return;
      }
      private double Tax = .12;
      private double LocationChange = .08;

      private double ChargeStuff(int tickets, double unitPrice)
       {
           double total = ( tickets *unitPrice) + Tax + LocationChange);
           return TaxRate * total + total;
       }

       public void POrder(){
//CardNo variable is made in OderClass.cs
         if (CheckCreditCard(OrderObject.CardNo))
                 {
                     double finalCharge = ChargeStuff(OrderObject.Amount, TicketPrice);
                     cout << ("Order from \n\tOrder Cost: " + OrderObject.finalCharge);
                     //still needs to send confermation to Ticket broker
                 }
                 else
                 {
                     cout << ("Order from " +OrderObject.Id +" has invalid credit card number " + OrderObject.CardNo);
                 }
       }
    }
}
