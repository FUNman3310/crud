using Microsoft.EntityFrameworkCore;

namespace BlogingSite.Models
{
    public class BlogContext:DbContext
    {

        public BlogContext(DbContextOptions<BlogContext> options):base(options) { }
        
        public  DbSet<Team> Teams { get; set; }

    }
}
