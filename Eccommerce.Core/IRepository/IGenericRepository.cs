using Eccommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.IRepository
{
    public interface IGenericRepository<T>where T: class
    {
        public Task<IEnumerable<T>>  GetAll(string? includeproprty = null);
        public Task<T> GetById(int id);
        public Task<T> AddT(T model);
        public T Update(T model);
        public void Delete(int id);


    }
}
