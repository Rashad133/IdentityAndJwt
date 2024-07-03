using AutoMapper;
using JWT.Api.DTOs;
using JWT.Api.Models;

namespace JWT.Api.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<RegisterDTO, AppUser>();
        }
    }
}
