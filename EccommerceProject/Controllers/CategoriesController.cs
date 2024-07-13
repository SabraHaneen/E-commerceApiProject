using Eccommerce.Core.Entities;
using Eccommerce.Core.IRepository;
using Eccommerce.Infrastructure.Data;
using Eccommerce.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EccommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
      //  private readonly ApplicationDbContext context;
        //  private readonly IGenericRepository<Categories> genericRepository;
      //  private readonly ICategoriesRepository categoriesRepository;
        private readonly IUniteOfWork<Categories> uniteOfWork;

        public CategoriesController(/*ApplicationDbContext context, ICategoriesRepository categoriesRepository*/  IUniteOfWork<Categories> uniteOfWork

            )
        {
          //  this.context = context;
           // this.categoriesRepository = categoriesRepository;
           this.uniteOfWork=uniteOfWork;
    }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model =await uniteOfWork.CategoriesRepository.GetAll();
          //  var model = categoriesRepository.GetAll();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            // var model = categoriesRepository.GetById(id);
            var model = await uniteOfWork.CategoriesRepository.GetById(id);
            return Ok(model);
        }
        [HttpPost]
        public async Task<ActionResult> Add(Categories req)
        {
           // categoriesRepository.AddT(req);
           await uniteOfWork.CategoriesRepository.AddT(req);

            return Ok(req);
        }
        [HttpPut]
        public async Task<ActionResult> updateProduct(Categories model)
        {
            //  categoriesRepository.Update(model);
            uniteOfWork.CategoriesRepository.Update(model);
            await uniteOfWork.Save();

            return Ok(model);
        }
        [HttpDelete]
        public async Task< ActionResult> Delete(int id)
        {
            uniteOfWork.CategoriesRepository.Delete(id);
            await uniteOfWork.Save();

            return Ok();
        }
    }
}
