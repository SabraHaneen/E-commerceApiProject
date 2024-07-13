using AutoMapper;
using Eccommerce.Core.Entities;
using Eccommerce.Core.Entities.DTO;
using Eccommerce.Core.IRepository;
using Eccommerce.Infrastructure.Data;
using EccommerceProject.MappProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EccommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // private readonly ApplicationDbContext context;
        //    private readonly IGenericRepository<Products> genericRepository;
        // private readonly IProductRepository productRepository;
        public ApiResponse response;//to have access to this entity
        private readonly IMapper mapper;
        private readonly IUniteOfWork<Products> uniteOfWork;

        public ProductController(/*ApplicationDbContext context, IProductRepository productRepository*/ IUniteOfWork<Products> uniteOfWork, IMapper mapper
            )
        {
         //   this.context = context;
            this.uniteOfWork = uniteOfWork;
            response = new ApiResponse();
           this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllProduct()
        {
            var model =await uniteOfWork.productRepository.GetAll(includeproprty: "Categories");
            // var model= productRepository.GetAll();
            var check = model.Any();//check if this model had data or not return boolean
            if (check)
            {
                response.StatuseCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = check;
                var mappedProducts = mapper.Map<IEnumerable<Products>, IEnumerable<ProductDTO>>(model);
                response.Result = mappedProducts;
                return response;//type apiresponse
            }
            else
            {
                response.ErrorMessages = "Product Not Found";
                response.StatuseCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = false;//or =check
                return response;//type apiresponse

            }
            return Ok(model);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            var model = await uniteOfWork.productRepository.GetById( id) ;
            return Ok(model);
        }
        [HttpPost]
        public async Task< ActionResult> Add(Products req)
        {
           await uniteOfWork.productRepository.AddT(req);
            // context.Products.Add(req);
            // context.SaveChanges();
            uniteOfWork.Save();
            return Ok(req);
        }
        [HttpPut]
        public async Task <ActionResult> updateProduct(Products model)
        {
            uniteOfWork.productRepository.Update(model);
            // context.SaveChanges();
          await  uniteOfWork.Save();

            return Ok(model);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            uniteOfWork.productRepository.Delete(id);
          await  uniteOfWork.Save();

            return Ok();
        }

        [HttpGet("Product/{cat_id}")]
        public async Task<IActionResult> GetProductCatID(int cat_id)
        {
         var products=await  uniteOfWork.productRepository.GettAllProductsByCategoryId(cat_id);
            var mappedProducts = mapper.Map<IEnumerable<Products>, IEnumerable<ProductDTO>>(products);
            return Ok(mappedProducts);
        }
    }
}
