using Core.Entities;

namespace Core.Specifications
{
    public class BlogWithSpecificationCount : BaseSpecification<BlogEntity>
    {
        public BlogWithSpecificationCount(BlogSpecificationParameters blogSpecificationParameters) :
            base(x => 
                (string.IsNullOrEmpty(blogSpecificationParameters.Search) || x.Name.ToLower().Contains(blogSpecificationParameters.Search)) &&
                (!blogSpecificationParameters.AuthorId.HasValue || x.BlogAuthorId == blogSpecificationParameters.AuthorId) &&
                (!blogSpecificationParameters.CategoryId.HasValue || x.BlogCategoryId == blogSpecificationParameters.CategoryId) &&
                (!blogSpecificationParameters.TagId.HasValue || x.TagId == blogSpecificationParameters.TagId)
            ) { }
    }
}