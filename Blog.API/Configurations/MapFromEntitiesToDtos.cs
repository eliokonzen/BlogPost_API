using AutoMapper;
using Blog.API.DTOs;
using Blog.Core.Entities;

namespace Blog.API.Configurations
{
    public class MapFromEntitiesToDtos : Profile
    {
        public MapFromEntitiesToDtos()
        {
            CreateMap<BlogPost, BlogPostDto>();
        }
    }
}
