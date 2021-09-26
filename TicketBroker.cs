using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project2
{
    class TicketBroker
    {
      private readonly ManualResetEvent pricecutevent = new ManualResetEvent(false);
      private readonly object SStuff = new object();
      private double ticketPrice;
      private DateTime timeSent;

      public void OnPriceCut(object src, PriceCutEventArgs new_price) //event handler
      {
          lock (SStuff)
          {
              ticketPrice = new_price.Price;
          }
          priceCutManualResetEvent.Set();
      }

      public void RunStore()
      {
          var orderTimes = new List<long>();
          //Uniquely identifies the thread its working on
          var CurrentTickets = Thread.CurrentThread.ManagedThreadId ; 
          var TicketsNeeded = Thread.CurrentThread.ManagedThreadId ;


                  int ticketamount;
                  lock (SStuff) //keeps from simultanious acess
                  {
                      ticketamount = CurrentTickets - TicketsNeeded * (int)(Tprice);
                  }
                  if (ticketamount > 0)
                  {
                      int Cnumber = Math.Min(7000, 5000 + Thread.CurrentThread.ManagedThreadId + ticketamount);
                      var OrderObject = new OrderClass
                                            {
                                                Amount = ticketamount,
                                                SenderId = Thread.CurrentThread.Name,
                                                CardNo = Cnumber
                                            };
                    
                      timeSent = DateTime.UtcNow;
                      string order = OrderObject;

                      //send encoded string to free cell in multiCellBuffer
                      var cell = new MultiCellBuffer(token);
                      try
                      {
                          cell.SetOneCell(order);

                          var eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset,Thread.CurrentThread.Name);
                          WaitHandle.WaitAny(new[] { eventWaitHandle, token.WaitHandle });

                          DateTime timeReceive = DateTime.UtcNow;
                          TimeSpan elapsedTime = timeReceive - timeSent;

                          Console.WriteLine("The order for {0} took {1} ms.", Thread.CurrentThread.Name,
                                            elapsedTime.Milliseconds);
                          orderTimes.Add(elapsedTime.Milliseconds);
                  }
            
          }
      }
    }
}
