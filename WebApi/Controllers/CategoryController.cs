using DTO;
using AutoMapper;
using BLL;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryBLL CategoryBLL;
        IMapper mapper;
        public CategoryController(ICategoryBLL _categoryBLL,IMapper _mapper)
        {
            CategoryBLL = _categoryBLL;
            mapper = _mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            return mapper.Map<List<Category>,List<CategoryDTO>>(CategoryBLL.getAllCategories());
        }


        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryDTO Get(int id)
        {
            return mapper.Map<Category,CategoryDTO>(CategoryBLL.getCategoryById(id));
        }
        [HttpGet("byname/{name}")]
        public CategoryDTO getCategoryByName(string name)
        {
            return mapper.Map < Category,CategoryDTO >(CategoryBLL.getCategoryByName(name));
        }

        // POST api/<CategoryController>
        [HttpPost]
        
        public void Post([FromBody] CategoryDTO category)
        {
            CategoryBLL.addCategory(mapper.Map<CategoryDTO, Category>(category));
           
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryDTO category)
        {
            CategoryBLL.updateCategory(mapper.Map<CategoryDTO, Category>((category)));
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoryBLL.removeCategory(id);
        }
    }
}
