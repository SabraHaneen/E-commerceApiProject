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
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private readonly ApplicationDbContext context;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<T>> GetAll(string? includeproprty=null)
        {
            /*  if (typeof(T) == typeof(Products))
              {
                  var model = await context.Products.Include(x => x.Categories).ToListAsync();
                  return (IEnumerable<T>)model;
              }
            */
            IQueryable<T> query = context.Set<T>();
            if (includeproprty != null)
            {
                query = query.Include(includeproprty);
            }

            return await query.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);

        }
        public async Task<T> AddT(T model)
        {
          await context.Set<T>().AddAsync(model);
        //    context.SaveChanges();
            return model;


        }
        public T Update(T model)
        {
            context.Set<T>().Update(model);
          //  context.SaveChanges();
            return model;
        }
        public void Delete(int id)
        {
            context.Remove(id);
         //   context.SaveChanges();
        }

    }
}
