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

            //discounts 
            double discountPerc = numOrderDiscount(num_orders) + availOrderDiscount(date_ordered);
            double percent = discountPerc * 100;

            double discPrice = original_price * discountPerc;

            //new calculated price
            new_price = original_price - discPrice;

            Console.WriteLine("The discount taken is {0} after a {1}%.", discPrice, percent);
            Console.WriteLine("The new price is {0}", new_price);

            return new_price;

        }

        //Calculate timespan of date order and give discount
        private static double availOrderDiscount(DateTime date_ordered)
        {
            TimeSpan dateDiff = DateTime.Now - date_ordered;
            int num_days = Int32.Parse(dateDiff.Days.ToString());

            if(num_days <= 5)
            {
                return 0.10;
            } else if (num_days >= 6 && num_days <= 10){
                return 0.15;
            } else if (num_days >= 11 && num_days <= 20){
                return 0.20;
            } else {
                return 0.30;
            }
        }

        //calculate discount based on number of orders
        private static double numOrderDiscount(int num_orders)
        {
           if(num_orders == 1)
           {
                return 1.10;
           } else {
                return 0.90;
           }
        }
    }
}
