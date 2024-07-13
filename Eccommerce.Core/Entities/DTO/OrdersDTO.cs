using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.Entities.DTO
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public string OrderStatus { set; get; }

        public DateTime OrderDate { get; set; }
        public int amount { get; set; }
        //relation btw user and order 1-m
        public string Users_Name { get; set; }
    }
}
