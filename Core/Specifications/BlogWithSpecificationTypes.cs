using System;
using Core.Entities;

namespace Core.Specifications
{
    public class BlogWithSpecificationTypes : BaseSpecification<BlogEntity>
    {
        public BlogWithSpecificationTypes(BlogSpecificationParameters blogSpecificationParameters) 
        :base(x => 
                (string.IsNullOrEmpty(blogSpecificationParameters.Search) || x.Name.ToLower().Contains(blogSpecificationParameters.Search)) &&
                (!blogSpecificationParameters.AuthorId.HasValue || x.BlogAuthorId == blogSpecificationParameters.AuthorId) &&
                (!blogSpecificationParameters.CategoryId.HasValue || x.BlogCategoryId == blogSpecificationParameters.CategoryId) &&
                (!blogSpecificationParameters.TagId.HasValue || x.TagId == blogSpecificationParameters.TagId)
            )
        {
            AddInclude(x => x.BlogCategories);
            AddInclude(x => x.BlogAuthor);
            AddInclude(x => x.Tags);
            AddOrderby(x => x.PublishedDate);
            ApplyPaging(blogSpecificationParameters.PageSize * (blogSpecificationParameters.PageIndex - 1), blogSpecificationParameters.PageSize);

            if (!string.IsNullOrEmpty(blogSpecificationParameters.Sort))
            {
                switch (blogSpecificationParameters.Sort)
                {
                    case "latest":
                        AddOrderbyDescending(n => n.PublishedDate);
                        break;
                    case "oldest":
                        AddOrderby(p => p.PublishedDate);
                        break;
                    default:
                        AddOrderby(n => n.Name);
                        break;
                }
            }
        }

        public BlogWithSpecificationTypes(int id) 
        : base(x => x.Id == id)
        {
            AddInclude(x => x.BlogCategories);
            AddInclude(x => x.BlogAuthor);
            AddInclude(x => x.Tags);
        }
    }
}