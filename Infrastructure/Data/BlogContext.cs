using System.Linq;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Infrastructure.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) :
            base(options)
        {
            
        }

        public DbSet<BlogEntity> BlogPosts { get; set; }

        public DbSet<BlogAuthor> BlogAuthors { get; set; }

        public DbSet<BlogCategories> BlogCategories { get; set; }

        public DbSet<BlogTags> BlogTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); }
    }
    
    
}