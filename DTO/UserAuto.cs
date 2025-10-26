using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserAuto: AutoMapper.Profile
    {
        public UserAuto()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
   
    }
}
