using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using static Services.Models.CommonModel;
namespace Services.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            AllowNullDestinationValues = true;
            CreateMap<UserModel, RolesModel>()
                .ForMember(dto => dto.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dto => dto.RoleName, opt => opt.MapFrom(src => src.RoleName));
            CreateMap<UserModel, LoginModel>()
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
