using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace Project2
{
    class PricingModel
    {

        //May use a random number generator
        private static Random random = new Random();

        public static double original_price = 0.0;
        public static double new_price = 0.0;

        //Must generate a price 40 <= P <= 200
        // Price will have multiple variables
        /* season (weekday)
             avalable number of tickets
            order received within a given time period
        */
        //calculate original price between 40 - 200, return new price
        public static double calc_newPrice(int num_orders, DateTime date_ordered)
        {
            original_price = random.Next(40, 200);

            Console.WriteLine("The number of tickets ordered {0} on  {1}.", num_orders, date_ordered);
            Console.WriteLine("Original Price was {0}", original_price);

            double total_ticketPrice = original_price * num_orders;

            Console.WriteLine("Price of the total number of ticket orders : ${0} ", total_ticketPrice);
            //discounts 
            double discountPerc = numOrderDiscount(num_orders) + availOrderDiscount(date_ordered);
            double percent = discountPerc * 100;

            double discPrice = total_ticketPrice * discountPerc;

            //new calculated price
            new_price = total_ticketPrice - discPrice;

            Console.WriteLine("The discount taken is {0} after a {1}%.", discPrice, percent);
            Console.WriteLine("The new price is {0}", new_price);

            return new_price;

        }

        //Calculate timespan of date order and give discount
        private static double availOrderDiscount(DateTime date_ordered)
        {
            TimeSpan dateDiff = date_ordered - DateTime.Now;
            int num_days = Int32.Parse(dateDiff.Days.ToString());
            Console.WriteLine("The number of days from order time {0}", num_days);

            if(num_days <= 5)
            {
                return 0.05;
            } else if (num_days >= 6 && num_days <= 10){
                return 0.10;
            } else if (num_days >= 11 && num_days <= 20){
                return 0.15;
            } else {
                return 0.20;
            }
        }

        //calculate discount based on number of orders
        private static double numOrderDiscount(int num_orders)
        {
           if(num_orders <= 5)
           {
                return 0.05;
           } else {
                return 0.10;
           }
        }
    }
}
