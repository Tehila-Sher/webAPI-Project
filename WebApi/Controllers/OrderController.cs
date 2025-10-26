using AutoMapper;
using BLL;
using DAL;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBLL orderBll;
        IMapper mapper;

        public OrderController(IOrderBLL _orderBll, IMapper _mapper)
        {
            orderBll= _orderBll;
            mapper= _mapper;
        }
        // GET: api/<orderController>
        [HttpGet]
        public IEnumerable<OrderDTO> Get()
        {
            return mapper.Map<IEnumerable<OrderDTO>>(orderBll.getAllOrders());
        }

        // GET api/<orderController>/5
        [HttpGet("{id}")]
        public OrderDTO get(int id)
        {
            return mapper.Map<Order, OrderDTO>(orderBll.getOrderById(id));
        }

        [HttpGet("user/{userId}")]
        public IEnumerable<OrderDTO> getAllUserOrders(int userId)
        {
            return mapper.Map<List<Order>,List<OrderDTO>>(orderBll.getAllUserOrders(userId));
        }

        // POST api/<orderController>
        [HttpPost]
        public void Post([FromBody] OrderDTO order)
        {
            orderBll.addOrder( mapper.Map<OrderDTO,Order>(order));
        }

        // PUT api/<orderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderDTO order)
        {
            orderBll.updateOrder(mapper.Map<OrderDTO, Order>(order));
        }

        // DELETE api/<orderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderBll.removeOrder(id);
        }
    }
}
