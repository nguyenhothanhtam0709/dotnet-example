using AutoMapper;
using DotnetExample.Core.Dto.Post;
using DotnetExample.Core.Models;

namespace DotnetExample.Core.App.Mapper;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<CreatePostDto, Post>();
        CreateMap<UpdatePostDto, Post>();
    }
}