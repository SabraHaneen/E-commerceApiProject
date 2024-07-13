using Eccommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.IRepository
{
    public interface IProductRepository:IGenericRepository<Products>
    {
        //  public void GetProductFilter();

        public Task<IEnumerable<Products>> GettAllProductsByCategoryId(int cat_Id);

    }
}
