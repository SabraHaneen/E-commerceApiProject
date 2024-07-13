using Eccommerce.Core.Entities;
using Eccommerce.Core.IRepository;
using Eccommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Infrastructure.Repository
{
    public class OrderRepository : GenericRepository<Orders>,IOrderRepository
    {
        private readonly ApplicationDbContext context;
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Orders>> GettAllordersByUserId(int userId)
        {
           
            var orders = await context.Orders.Where(c => c.UsersId == userId).ToListAsync();
            foreach (var order in orders)
            {
                await context.Entry(order).Reference(r => r.Users).LoadAsync();
            }
            return orders;


        }
    }
}
