using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyModel;

namespace MyWcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service”。
    public class OrderService : IOrderService
    {
        public void PlaceOrder(OrderEntry entry)
        {
            Console.WriteLine("收到信息:\n{0}",entry);
        }
    }
}
