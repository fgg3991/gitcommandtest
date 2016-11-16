using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Messaging;
using MyWcfService;

namespace MyHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string ex1QueueName = @".\private$\ex1Queue";
            MessageQueue MQ = null;
            if (!MessageQueue.Exists(ex1QueueName))
                MQ = MessageQueue.Create(ex1QueueName);
            else
                MQ = new MessageQueue(ex1QueueName);

            ServiceHost host = new ServiceHost(typeof(MyWcfService.OrderService),
                new Uri ("net.msmq://localhost/private/ex1Queue"));
            NetMsmqBinding binding = new NetMsmqBinding(NetMsmqSecurityMode.None);
            binding.ExactlyOnce = false;
            binding.Durable = true;
            host.AddServiceEndpoint(typeof(IOrderService).FullName, binding, "");

            if (host.State != CommunicationState.Opening)
                host.Open();
            Console.WriteLine("Host is running, State:{0}",host.State);
            Console.ReadLine();
            host.Close();
        }
    }
}
