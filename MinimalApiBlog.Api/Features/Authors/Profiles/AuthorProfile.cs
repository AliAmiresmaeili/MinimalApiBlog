using AutoMapper;
using MinimalApiBlog.Api.Features.Authors.Models;
using MinimalApiBlog.Domain.Model;

namespace MinimalApiBlog.Api.Features.Authors.Profiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<Author, AuthorGetDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
