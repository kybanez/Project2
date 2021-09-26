using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project2
{
    public delegate void priceCutEvent(Int32 pr);
    
    class Program
    {
        private const int K = 2;
        private const int N = 5;

        private static Thread[] theater_threads = new Thread[K];
        private static Thread[] ticketBroker_threads = new Thread[N];

        private static Theater[] theaters = new Theater[K];

        public static MultiCellBuffer buffer = new MultiCellBuffer();
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Theater Threading Simulator....");

            //Initialize theater
            for(int i = 0; i < K; ++i)
            {
                Theater theater = new Theater();
                theaters[i] = theater;
                theater_threads[i] = new Thread(theater.Run_theater);
                theater_threads[i].Name = "Theater: " + i;
                theater_threads[i].Start();
                while (!theater_threads[i].IsAlive) ;
            }

            //Initialize Ticket Brokers
            for (int i = 0; i < N; ++i)
            {
                TicketBroker ticketBroker = new TicketBroker();

                for(int j = 0; j < K; ++j)
                {
                    ticketBroker.subscribe(theaters[j]);
                }

                ticketBroker_threads[i] = new Thread(ticketBroker.Run_ticketBroker);
                ticketBroker_threads[i].Name = "Ticket Broker: " + i;
                ticketBroker_threads[i].Start();
                while (!ticketBroker_threads[i].IsAlive) ;
            }

            //wait to perform max cuts
            for (int i = 0; i <K; ++i)
            {
                while (theater_threads[i].IsAlive) ;
            }

            //alert ticket broker that theater is inactive
            for(int i = 0; i<N; ++i)
            {
                TicketBroker.setTheaterActive(false);
            }

            for (int i = 0; i < N; ++i)
            {
                while (ticketBroker_threads[i].IsAlive) ;
            }

            Console.WriteLine("\nEND OF PROGRAM\n");

            Console.WriteLine("Press any key to continue ... \n");
            Console.ReadLine();
        }
    }
}
