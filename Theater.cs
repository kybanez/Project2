using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project2
{
    class Theater
    {

        private const int max_priceCut = 20;

        private int priceCut_cnt = 1;

        private double new_Price = 0.0;
        private double prev_Price = 0.0;

        private static Random rnd = new Random();
        private static Random rand_date = new Random();

        public delegate void PriceCutHandler(PriceCutEventArgs p);
        public event PriceCutHandler priceCut;

        private MultiCellBuffer buffer;

        private ArrayList orderThreads = new ArrayList();

        public double getPrice()
        {
            return new_Price;
        }

        //Stop after t-many price cuts
        //Emmiting event to ticketbroker if price change (new price < oldprice)
        public void Run_theater()
        {
           while (priceCut_cnt <= max_priceCut)
            {
                Set_ticketPrice();
                Console.WriteLine("Price: {0}", new_Price);
                if (new_Price < prev_Price)
                {
                    Console.WriteLine("\n----------PRICE CUT OCCURING---------------\n");
                    PriceCutEvent();
                }

                prev_Price = new_Price;
                process_Order(ret_Order(Thread.CurrentThread.Name),new_Price);
            }

           foreach (Thread item in orderThreads)
            {
                while (item.IsAlive) ;
            }

            Console.WriteLine("Theater Thread {0} is being closed.", Thread.CurrentThread.Name);


        }

        //Using pricing model to set dynamic pricing

        public void Set_ticketPrice()
        {
            DateTime now = DateTime.Now;
            int range = rand_date.Next(1,36);

            Console.WriteLine("Today's date is {0}", now.Date);
            DateTime order_date = DateTime.Now.AddDays(range);

            prev_Price = new_Price;
            Random rand_numOrder = new Random();
            int num_order = rand_numOrder.Next(1, 2);

            new_Price = PricingModel.calc_newPrice(num_order, order_date);
            prev_Price = PricingModel.original_price;

        }

        //Receiving order from MultiCellBuffer
       


        //Ccreate order Processing thread
        public void process_Order(OrderClass order, double new_price)
        {
            if(order.receiverID == Thread.CurrentThread.Name || order.receiverID == null)
            {
                Console.WriteLine("Order for Theater {0}", Thread.CurrentThread.Name);
                OrderProcessing processer = new OrderProcessing(order, new_price);
                Thread orderThread = new Thread(new ThreadStart(processer.POrder));
                orderThreads.Add(orderThread);
                orderThread.Name = "Processor_" + Thread.CurrentThread.Name;
                orderThread.Start();
            } else
            {
                Console.WriteLine("Order not for Theater {0}", Thread.CurrentThread.Name);
            }
        }


        //For each order, spawn an order processing thread
        public OrderClass ret_Order(string order)
        {
            return (Program.buffer.getBuffer(order));
        }

        //Method started by main

        
       
        //Defines a price cut event to call event handlers in broker 
        public void PriceCutEvent()
        {
            if(priceCut != null)
            {
                Console.WriteLine("Performing Price Cut Event #{0} {1}]n", priceCut_cnt, Thread.CurrentThread.Name);
                priceCut_cnt++;
                priceCut(new PriceCutEventArgs(Thread.CurrentThread.Name, new_Price));
            } else
            {
                Console.WriteLine("No subscribers \n");
            }
        }
        
    }

}
