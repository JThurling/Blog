using System;

namespace Core.Entities
{
    public class BlogEntity : BaseEntity
    {
        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public BlogAuthor BlogAuthor { get; set; }

        public int BlogAuthorId { get; set; }

        public BlogCategories BlogCategories { get; set; }

        public int BlogCategoryId { get; set; }

        public BlogTags Tags { get; set; }

        public int TagId { get; set; }
    }
}