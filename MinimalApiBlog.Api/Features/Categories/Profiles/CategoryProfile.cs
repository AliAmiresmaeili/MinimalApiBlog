using AutoMapper;
using MinimalApiBlog.Api.Features.Categories.Models;
using MinimalApiBlog.Domain.Model;

namespace MinimalApiBlog.Api.Features.Categories.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();

        }
    }
}
