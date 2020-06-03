using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class BlogController : BaseApiController
    {
        private readonly IGenericRepository<BlogEntity> _blogRepository;


        public BlogController(IGenericRepository<BlogEntity> blogRepository,
            IGenericRepository<BlogAuthor> authorRepository,
            IGenericRepository<BlogTags> tagRepository,
            IGenericRepository<BlogCategories> categoryRepository)
        {
            _blogRepository = blogRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<BlogEntity>>> GetBlogPosts()
        {
            var spec = new BlogWithSpecificationTypes();

            var blogPosts = await _blogRepository.ListAsync(spec);
            
            return Ok(blogPosts);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogEntity>> GetBlogPost(int id)
        {
            var spec = new BlogWithSpecificationTypes(id);

            var blogPost = await _blogRepository.GetEntityWithSpec(spec);

            return Ok(blogPost);
        }
        
        // [HttpGet("author")]
        // public async Task<IReadOnlyList<BlogAuthor>> GetBlogAuthor()
        // {
        //     return await _service.GetBlogAuthorsAsync();
        // }
        //
        // [HttpGet("categories")]
        // public async Task<IReadOnlyList<BlogAuthor>> GetBlogCategories()
        // {
        //     return await _service.GetBlogAuthorsAsync();
        // }
        //
        // [HttpGet("tags")]
        // public async Task<IReadOnlyList<BlogAuthor>> GetBlogTags()
        // {
        //     return await _service.GetBlogAuthorsAsync();
        // }
    }
}