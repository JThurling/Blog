using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class BlogSeed
    {
        public static async Task SeedAsync(BlogContext context)
        {
            try
            {
                if (!context.BlogCategories.Any())
                {
                    var categories = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");

                    var category = JsonSerializer.Deserialize<List<BlogCategories>>(categories);

                    foreach (var item in category)
                    {
                        context.BlogCategories.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
                if (!context.BlogAuthors.Any())
                {
                    var authors = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/authors.json");

                    var author = JsonSerializer.Deserialize<List<BlogAuthor>>(authors);

                    foreach (var item in author)
                    {
                        context.BlogAuthors.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
                
                if (!context.BlogTags.Any())
                {
                    var tags = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/tags.json");

                    var tag = JsonSerializer.Deserialize<List<BlogTags>>(tags);

                    foreach (var item in tag)
                    {
                        context.BlogTags.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
                if (!context.BlogPosts.Any())
                {
                    var posts = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/blogs.json");

                    var post = JsonSerializer.Deserialize<List<BlogEntity>>(posts);

                    foreach (var item in post)
                    {
                        context.BlogPosts.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}