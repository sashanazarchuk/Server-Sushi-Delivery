using BusinessLogic.DTOs;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Profiles
{
    public class ApplicationProfile: AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<FoodDto, Food>();
            CreateMap<Food, FoodDto>();
        

            CreateMap<UserDto, IdentityUser>()
             .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Email))
             .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
