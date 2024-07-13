using Eccommerce.Core.IRepository;
using Eccommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Infrastructure.Repository
{
    public class UnitOfWork<T>:IUniteOfWork<T> where T:class
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            productRepository = new ProductRepository(context);
            CategoriesRepository = new CategoriesRepository(context);

            orderRepository = new OrderRepository(context);     
        }

public IProductRepository productRepository { get; set; }
        public ICategoriesRepository CategoriesRepository { get; set; }
        public IOrderRepository orderRepository { get; set; }

        public async Task<int> Save()
        {
            return  context.SaveChanges();
        }
    }
   
   


}
