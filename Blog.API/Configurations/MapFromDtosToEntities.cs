using AutoMapper;
using Blog.API.DTOs;
using Blog.Core.Entities;

namespace Blog.API.Configurations
{
    public class MapFromDtosToEntities : Profile
    {
        public MapFromDtosToEntities()
        {
            CreateMap<UpdateBlogPostDto, BlogPost>();
            CreateMap<CreateBlogPostDto, BlogPost>();
        }
    }
}
