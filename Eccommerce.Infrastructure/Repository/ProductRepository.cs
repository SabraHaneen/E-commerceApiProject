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
    public class ProductRepository  :GenericRepository<Products>, IProductRepository
    {
        private readonly ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Products>> GettAllProductsByCategoryId(int cat_Id)
        {
            /*   //1-using Eager loading
               var products = await context.Products.Include(x => x.Categories).Where(c => c.CategoriesId == cat_Id).ToListAsync();
               return products;*/
            //2-Explicit lodaing
            var products = await context.Products.Where(c => c.CategoriesId == cat_Id).ToListAsync();
            foreach(var product in products)
            {
             await  context.Entry(product).Reference(r => r.Categories).LoadAsync();//reference to get refernce i want from entity
              
            }
            return products;


            //3-Lazy Loading and this method need to First :download lazy loading Package called proxises v of my .net
            //Second: need to tell my program that i wanna defualtConnection.UseLazyLoadingProxies so the entity will understand that it will use lazy loading
            //third setp in my navegation property (in products class add virtual before property name//public virtual Categories?categories{get;set;})
            // then define var prod=await context.Products.Where(c=>c.CategoriesId==cat_id).ToListAsync;return pro;
            //in lazy loading related data if i wanna use it it will get it if i donnot wanna use it it will not
        }
    }
}
