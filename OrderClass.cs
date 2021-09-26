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
        private string receverId;// recever thread name , 
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


        public string getReceiverId()
        {
            return receverId;
        }

        public void setReceiverId(string r_ID)
        {
            receverId = r_ID;
        }
       

        public override string ToString()
        {
            string order = "Order Ticket \n\t {SENDER ID: " + senderId
                + "} \n\t {RECEIVER ID: " + receverId
                + "} \n\t {CARD_NO: " + cardNo
                + "} \n\t {QUANTITY: " + quantity
                + "} \n\t {DATE CREATED: " + TimeStamp.ToString("D") + "}";

            return order;
        }
    }

}
