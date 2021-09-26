using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class OrderClass
    {
          private double unitPrice; //ticket unit price
  private int cardNo;//credit card numbrt
  private int amount; //ticket amount
  private string senderId; // sender id
  private string receverId;// recever if

  public int CardNum
        {
            get {
                return cardNo; 
                }
            set 
            { 
                cardNo = value; 
            }
        }
  public int Amount
        {
            get {
                return amount; 
            }
            set {
                amount = value;
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
    }
}
