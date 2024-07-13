using Eccommerce.Core.Entities;
using Eccommerce.Core.IRepository;
using Eccommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Infrastructure.Repository
{    public class CategoriesRepository:GenericRepository<Categories>,ICategoriesRepository
    {
        private readonly ApplicationDbContext context;
        public CategoriesRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
