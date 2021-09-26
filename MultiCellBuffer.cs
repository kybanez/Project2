using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project2
{
    class MultiCellBuffer
    {
        public static Semaphore semaphore = new Semaphore(0, 3);
        private static OrderClass[] buffer = new OrderClass[3];
       

        public void setBuffer(OrderClass new_Order)
        {
           lock(buffer)
            {
                for (int i =0; i < buffer.Length; i++)
                {
                    if(buffer[i] == null)
                    {
                        buffer[i] = new_Order;

                        return;
                    }
                }
                semaphore.WaitOne();
            }
        }

        public OrderClass getBuffer(string sendId)
        {
            lock(buffer)
            {
                OrderClass order = new OrderClass();

                int index = -1;

                for(int i = 0; i < buffer.Length; i++)
                {
                    if(buffer[i] != null)
                    {
                        order = buffer[i];
                        
                        if(order.getSenderId() == sendId)
                        {
                            index = i;
                        }
                    }
                }

                if(index != -1)
                {
                    buffer[index] = null;
                }
                semaphore.Release();
                return order;
            }
        }
    }


}
