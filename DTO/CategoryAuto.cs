using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryAuto: AutoMapper.Profile
    {
        public CategoryAuto()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
