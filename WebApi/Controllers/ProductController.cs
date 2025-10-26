using AutoMapper;
using BLL;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBLL productBLL;
        IMapper mapper;

        public ProductController(IProductBLL _productBLL, IMapper _mapper)
        {
            productBLL = _productBLL;
            mapper = _mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            return mapper.Map<List<Product>,List<ProductDTO>>(productBLL.getAllProducts());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDTO Get(int id)
        {
            return mapper.Map<Product,ProductDTO>(productBLL.getProductById(id));
        }
        [HttpGet("byname/{name}")]
        public ProductDTO getProductByName(string name)
        {
            return mapper.Map<Product, ProductDTO>(productBLL.getProductByName(name));
        }
        [HttpGet("bycategory/{categoryId}")]
        public IEnumerable<ProductDTO> getAllProductsByCategory(int categoryId)
        {
            return mapper.Map<List<Product>, List<ProductDTO>>(productBLL.getAllProductsByCategory(categoryId));
        }
       
        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductDTO product)
        {
            productBLL.addProduct(mapper.Map< ProductDTO,Product>(product));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDTO product)
        {
            productBLL.updateProduct(mapper.Map < ProductDTO, Product > (product));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productBLL.removeProduct(id);
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("לא נבחר קובץ");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // נחזיר את הנתיב היחסי שישמר בבסיס הנתונים
            var relativePath = $"/images/{fileName}";
            return Ok(new { path = relativePath });
        }
    }
}
