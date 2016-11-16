using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using MyWcfService;
using MyModel;
namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            NetMsmqBinding binding = new NetMsmqBinding(NetMsmqSecurityMode.None);
            binding.ExactlyOnce = false;
            binding.Durable = true;

            ChannelFactory<IOrderService> channel =
                new ChannelFactory<IOrderService>(binding, new EndpointAddress("net.msmq://localhost/private/ex1Queue"));

            IOrderService client = channel.CreateChannel();

            OrderEntry user1 = new OrderEntry(){Id ="001",Date = DateTime.Now};
            client.PlaceOrder(user1);
            Console.WriteLine("信息已发送.");
            Console.ReadKey();

            channel.Close();
        }
    }
}
