using AutoMapper;
using Eccommerce.Core.Entities;
using Eccommerce.Core.Entities.DTO;
using Eccommerce.Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eccommerce.Infrastructure.Data;
using EccommerceProject.MappProfile;

using System.Collections.Generic;

namespace EccommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public ApiResponse response;//to have access to this entity
        private readonly IMapper mapper;
        private readonly IUniteOfWork<Orders> uniteOfWork;
        public OrderController( IUniteOfWork<Orders> uniteOfWork, IMapper mapper
          )
        {
            //   this.context = context;
            this.uniteOfWork = uniteOfWork;
            response = new ApiResponse();
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            var model = await uniteOfWork.orderRepository.GetAll(includeproprty: "Users");
            var check = model.Any();
            if (check)
            {
                response.StatuseCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = check;
                var mappedProducts = mapper.Map<IEnumerable<Orders>, IEnumerable<OrdersDTO>>(model);
                response.Result = mappedProducts;
                return response;
            }
            else
            {
                response.ErrorMessages = "Product Not Found";
                response.StatuseCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = false;
                return response;

            }
            return Ok(model);
        }

        [HttpGet("Orders/{userId}")]
        public async Task<IActionResult> GettAllordersByUserId(int userId)
        {
            var orders = await uniteOfWork.orderRepository.GettAllordersByUserId(userId);
            var mappedOrders = mapper.Map<IEnumerable<Orders>, IEnumerable<OrdersDTO>>(orders);
            return Ok(mappedOrders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            var model = await uniteOfWork.orderRepository.GetById(id);
            return Ok(model);
        }
        [HttpPost]
        public async Task<ActionResult> Add(Orders req)
        {
            await uniteOfWork.orderRepository.AddT(req);
            
            uniteOfWork.Save();
            return Ok(req);
        }

        [HttpPut]
        public async Task<ActionResult> updateOrder(Orders model)
        {
            uniteOfWork.orderRepository.Update(model);
            await uniteOfWork.Save();

            return Ok(model);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            uniteOfWork.orderRepository.Delete(id);
            await uniteOfWork.Save();

            return Ok();
        }
    }
}
