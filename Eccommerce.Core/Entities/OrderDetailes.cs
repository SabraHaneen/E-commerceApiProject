using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.Entities
{
    public class OrderDetailes
    {
        //orderDetailesId,orderId,productid composet key
        public int Id { get; set; }

        public int OrdersId;//fk from orderTable
        public int ProductsId;//fk from product Table
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Orders? Orders { get; set; }
        public Products? Products { get; set; }
    }
}
