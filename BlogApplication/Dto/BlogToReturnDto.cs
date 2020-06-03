using System;

namespace BlogApplication.Dto
{
    public class BlogToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogCategories { get; set; }
        public string Tags { get; set; }
    }
}