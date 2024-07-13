using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //relation btw products and categories many of products
        public ICollection<Products> Products { get; set; } = new HashSet<Products>();//use hash to get uniqe elemenets without duplication

    }
}
