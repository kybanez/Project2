using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class OrderClass
    {
        private double unitPrice; //ticket unit price; tickets received from theater
        private int cardNo;//credit card numbrt
        private int amount; //ticket amount
        private int quantity; // # of tickets ordered
        private string senderId; // sender id , thread ID, ticketbroker
        private string receiverId;// recever thread name , 
        private double total_price;
        private DateTime timestamp = DateTime.Today;

      
       
        public int CardNum
        {
            get
            {
                return cardNo;
            }
            set
            {
                cardNo = value;
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public string receiverID
        {
           get
            {
                return receiverId;
            }
            set
            {
                receiverId = value;
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            } 
            set
            {
                quantity = value;
            }
        }

        public void setCardNo(int num)
        {
            cardNo = num;
        }
        public int getCardNo()
        {
            return cardNo;
        }

        public void setAmount(int astuff)
        {
            amount = astuff;
        }
        public int getAmount()
        {
            return amount;
        }

        public DateTime TimeStamp
        {
            get
            {
                return timestamp;
            } 
            set
            {
                timestamp = value;
            }
        }

        public string getSenderId()
        {   
            return senderId;
        } 
        public void setSenderID(string s_ID)
        {
            senderId = s_ID;
        }

       public double totalPrice()
        {
            total_price = quantity * unitPrice;
            return total_price;
           
        }


        public override string ToString()
        {
            string order = "\nOrder Ticket \n" +
                "\nSENDER ID: " + senderId
                + "\n\tRECEIVER ID: " + receiverId
                + "\n\tCARD_NO: " + cardNo
                + "\n\tQUANTITY: " + quantity
                + "\n\tTICKET PRICE: $" + unitPrice
                + "\n\tORDER COST: $" + total_price
                + "DATE CREATED: " + TimeStamp.ToString("D") ;

            return order;
        }
    }

}
