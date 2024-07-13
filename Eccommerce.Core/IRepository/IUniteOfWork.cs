using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.IRepository
{
    public interface IUniteOfWork<T>where T:class
    {
        public IProductRepository productRepository { get; set; }
        public ICategoriesRepository CategoriesRepository { get; set; }
public IOrderRepository orderRepository { get; set; }


            public  Task<int> Save();
    }
}
