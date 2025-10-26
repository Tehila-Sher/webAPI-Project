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
    public class UserController : ControllerBase
    {
        IUserBLL userBLL;
        IMapper mapper;

        public UserController(IUserBLL _userBll, IMapper _mapper)
        {
            userBLL = _userBll;
            mapper = _mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return mapper.Map<List<User>,List<UserDTO>>(userBLL.getAllUsers());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            return mapper.Map<User, UserDTO>(userBLL.getUserById(id));
        }
        [HttpGet("byname/{name}")]
        public UserDTO getUserByName(string name)
        {
            return mapper.Map<User, UserDTO>(userBLL.getUserByName(name));
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserDTO user)
        {
            userBLL.addUser(mapper.Map < UserDTO, User > (user));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDTO user)
        {
            userBLL.updateUser(mapper.Map<UserDTO, User>(user));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)

        {
            userBLL.removeUser(id);
        }
    }
}
