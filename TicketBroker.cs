using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project2
{
    class TicketBroker
    {
        //private readonly ManualResetEvent pricecutevent = new ManualResetEvent(false);
        private readonly object SStuff = new object();
        private double ticketPrice;
        private DateTime timeSent;
        private string TheaterID; 

        private Random CC_rnd = new Random();
        private Random rand = new Random();
        private static bool TheaterActive = true;
        private bool ticket_Demand = true;
        private bool bulk_Order = false;

        public static int[] CC = new int[5];
        private void create_CC()
        {
            for(int i = 0; i < 5; i++)
            {
                int temp_CC = CC_rnd.Next(5000, 7000);
                CC[i] = temp_CC;
            }
        }


       /* public void OnPriceCut(object src, PriceCutEventArgs new_price) //event handler
        {
            lock (SStuff)
            {
                ticketPrice = new_price.Price;
            }
            priceCutManualResetEvent.Set();
        }*/

        public void Run_ticketBroker()
        {
            while (TheaterActive)
            {
                if(ticket_Demand)
                {
                    if (bulk_Order)
                    {
                        Generate_bOrder(TheaterID);
                    }
                    else
                    {
                        Generate_sOrder(TheaterID);
                    }
                } 
                else
                {
                    Console.WriteLine("Ticket Broker Thread {0}", Thread.CurrentThread.Name);
                    Thread.Sleep(1000);
                    ticket_Demand = true;
                }
            }

            Console.WriteLine("Closing Ticket Broker Thread {0}", Thread.CurrentThread.Name);
        }

        public void subscribe(Theater t)
        {
            Console.WriteLine("Subscribing to price cut event");
            t.priceCut += issue_bOrder;
        }

        private void Generate_bOrder(string theaterID)
        {
            
            Console.WriteLine("Bulk Order {0} is creating.", Thread.CurrentThread.Name);

            ticket_Demand = false;
            OrderClass order = new OrderClass();
            order.Amount = 25;
            order.CardNum = CC[rand.Next(0, 4)];
            order.setSenderID(Thread.CurrentThread.Name);
            order.receiverID = theaterID;

            Program.buffer.semaphore.WaitOne();
            Program.buffer.setBuffer(order);


        }

        private void Generate_sOrder(string theaterID)
        {
            Console.WriteLine("Single Order {0}", Thread.CurrentThread.Name);

            ticket_Demand = false;
            OrderClass order = new OrderClass();
            order.Amount = 10;
            order.CardNum = CC[rand.Next(0, 4)];
            order.setSenderID(Thread.CurrentThread.Name);
            order.receiverID = theaterID;

            Program.buffer.setBuffer(order);
                
        }

        public void issue_bOrder(PriceCutEventArgs e)
        {
            bulk_Order = true;
            TheaterID = e.Id;
            ticketPrice = e.Price;
        }

        public static void setTheaterActive(bool status)
        {
            TheaterActive = status;
        }

        public static bool getTheaterActive()
        {
            return TheaterActive;
        }
    }
}