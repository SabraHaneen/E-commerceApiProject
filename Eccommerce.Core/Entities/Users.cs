using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        //USER->Order 1-M
        public ICollection<Orders> Orders { get; set; } = new HashSet<Orders>();//use hash to get uniqe elemenets without duplication

    }
}
