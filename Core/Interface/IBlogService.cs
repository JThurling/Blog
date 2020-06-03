using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IBlogService
    {
        Task<BlogEntity> GetBlogPostAsync(int id);

        Task<IReadOnlyList<BlogEntity>> GetBlogPostsAsync();

        Task<IReadOnlyList<BlogAuthor>> GetBlogAuthorsAsync();

        Task<IReadOnlyList<BlogCategories>> GetBlogCategoriesAsync();
        
        Task<IReadOnlyList<BlogTags>> GetBlogTagsAsync();
    }
}