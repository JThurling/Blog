using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BlogService : IBlogService
    {
        private readonly BlogContext _context;

        public BlogService(BlogContext context)
        {
            _context = context;
        }
        
        public async Task<BlogEntity> GetBlogPostAsync(int id)
        {
            return await _context.BlogPosts
                .Include(p => p.BlogAuthor)
                .Include(p => p.BlogCategories)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IReadOnlyList<BlogEntity>> GetBlogPostsAsync()
        {
            return await _context.BlogPosts
                .Include(p => p.BlogAuthor)
                .Include(p => p.BlogCategories)
                .Include(p => p.Tags)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<BlogAuthor>> GetBlogAuthorsAsync()
        {
            return await _context.BlogAuthors.ToListAsync();
        }

        public async Task<IReadOnlyList<BlogCategories>> GetBlogCategoriesAsync()
        {
            return await _context.BlogCategories.ToListAsync();
        }

        public async Task<IReadOnlyList<BlogTags>> GetBlogTagsAsync()
        {
            return await _context.BlogTags.ToListAsync();
        }
    }
}