using AutoMapper;
using BlogApplication.Dto;
using Core.Entities;

namespace BlogApplication.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BlogEntity, BlogToReturnDto>()
                .ForMember(d => d.BlogAuthor, o => o.MapFrom(s => s.BlogAuthor.Name))
                .ForMember(d => d.BlogCategories, o => o.MapFrom(s => s.BlogCategories.Name))
                .ForMember(d => d.Tags, o => o.MapFrom(s => s.Tags.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}