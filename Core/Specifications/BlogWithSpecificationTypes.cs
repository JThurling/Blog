using Core.Entities;

namespace Core.Specifications
{
    public class BlogWithSpecificationTypes : BaseSpecification<BlogEntity>
    {
        public BlogWithSpecificationTypes()
        {
            AddInclude(x => x.BlogCategories);
            AddInclude(x => x.BlogAuthor);
            AddInclude(x => x.Tags);
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