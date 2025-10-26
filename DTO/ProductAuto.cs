using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductAuto: AutoMapper.Profile
    {
        public ProductAuto()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
