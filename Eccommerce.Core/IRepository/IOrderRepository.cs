using Eccommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.IRepository
{
    public interface IOrderRepository: IGenericRepository<Orders>
    {
        public Task<IEnumerable<Orders>> GettAllordersByUserId(int userId);

    }
}
