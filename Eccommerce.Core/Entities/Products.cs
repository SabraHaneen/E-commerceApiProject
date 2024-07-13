using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? Image { get; set; }//nullbale if i don't want to enter img
        //product->Categories M-1 SO Navegation propierties add category id in product table
        public int CategoriesId { get; set; }
        public Categories? Categories { get; set; }//nullable when we create new product and wanna map it this property will be null
        //product->OrderDetailes ONE PRODECT CAN EXSITS MANY TIME IN ORDERDETAILES
        public ICollection<OrderDetailes>? OrderDetailes { get; set; } = new HashSet<OrderDetailes>();//use hash to get uniqe elemenets without duplication

    }
}
