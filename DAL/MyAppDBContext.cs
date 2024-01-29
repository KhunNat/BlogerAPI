using BlogerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogerAPI.DAL
{
    public class MyAppDBContext : DbContext
    {
        public MyAppDBContext(DbContextOptions options) : base(options) 
        { 

        }
        public DbSet<CategoryModel> Categorys { get; set; }
        public DbSet<PostModel> Posts { get; set; }
    }
}
