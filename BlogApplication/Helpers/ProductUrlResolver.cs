using AutoMapper;
using BlogApplication.Dto;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace BlogApplication.Helpers
{
    public class ProductUrlResolver : IValueResolver<BlogEntity, BlogToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string Resolve(BlogEntity source, BlogToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }

            return null;

        }
    }
}