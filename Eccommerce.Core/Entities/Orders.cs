using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public string OrderStatus { set; get; }

        public DateTime OrderDate { get; set; }
        public int amount { get; set; }
        //relation btw user and order 1-m
        public int UsersId { get; set; }
        public Users? Users { get; set; }

        //ORDER->OrderDetailes ONE ORDER CAN EXSITS MANY TIME IN ORDERDETAILES(M-1)
        public ICollection<OrderDetailes> OrderDetailes { get; set; } = new HashSet<OrderDetailes>();//use hash to get uniqe elemenets without duplication


    }
}
