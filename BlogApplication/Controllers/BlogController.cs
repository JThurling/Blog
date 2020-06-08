using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlogApplication.Dto;
using BlogApplication.Helpers;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class BlogController : BaseApiController
    {
        private readonly IGenericRepository<BlogEntity> _blogRepository;
        private readonly IGenericRepository<BlogAuthor> _authorRepository;
        private readonly IGenericRepository<BlogTags> _tagRepository;
        private readonly IGenericRepository<BlogCategories> _categoryRepository;
        private readonly IMapper _mapper;


        public BlogController(IGenericRepository<BlogEntity> blogRepository,
            IGenericRepository<BlogAuthor> authorRepository,
            IGenericRepository<BlogTags> tagRepository,
            IGenericRepository<BlogCategories> categoryRepository,
            IMapper mapper)
        {
            _blogRepository = blogRepository;
            _authorRepository = authorRepository;
            _tagRepository = tagRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<Paging<BlogToReturnDto>>> GetBlogPosts(
            [FromQuery] BlogSpecificationParameters blogSpecificationParameters)
        {
            var spec = new BlogWithSpecificationTypes(blogSpecificationParameters);

            var blogPosts = await _blogRepository.ListAsync(spec);
            
            var blogList = _mapper.Map<IReadOnlyList<BlogEntity>, IReadOnlyList<BlogToReturnDto>>(blogPosts);

            return Ok(new Paging<BlogToReturnDto>(blogSpecificationParameters.PageIndex, blogSpecificationParameters.PageSize, blogList));
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<BlogToReturnDto> GetBlogPost(int id)
        {
            var spec = new BlogWithSpecificationTypes(id);

            var blogPost = await _blogRepository.GetEntityWithSpec(spec);

            return _mapper.Map<BlogEntity, BlogToReturnDto>(blogPost);
        }
        
        [HttpGet("author")]
        public async Task<ActionResult<IReadOnlyList<BlogAuthor>>> GetBlogAuthor()
        {
            return Ok(await _authorRepository.ListAllAsync());
        }
        
        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<BlogCategories>>> GetBlogCategories()
        {
            return Ok(await _categoryRepository.ListAllAsync());
        }
        
        [HttpGet("tags")]
        public async Task<ActionResult<IReadOnlyList<BlogTags>>> GetBlogTags()
        {
            return Ok(await _tagRepository.ListAllAsync());
        }
    }
}