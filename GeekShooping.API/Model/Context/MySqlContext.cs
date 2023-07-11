using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() { }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Name 2",
                Price = 62.9M,
                Description = "Description T-Shirt 2",
                ImageUrl = "https://raw.githubusercontent.com/leleomaster/leo-microservices-dotnet6/master/ShoppingImages/11_mars.jpg",
                CategoryName = "T-Shirt 2"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Name 3",
                Price = 63.9M,
                Description = "Description T-Shirt 3",
                ImageUrl = "https://raw.githubusercontent.com/leleomaster/leo-microservices-dotnet6/master/ShoppingImages/11_mars.jpg",
                CategoryName = "T-Shirt 3"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Name 4",
                Price = 64.9M,
                Description = "Description T-Shirt 4",
                ImageUrl = "https://raw.githubusercontent.com/leleomaster/leo-microservices-dotnet6/master/ShoppingImages/11_mars.jpg",
                CategoryName = "T-Shirt 4"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Name 5",
                Price = 65.9M,
                Description = "Description T-Shirt 5",
                ImageUrl = "https://raw.githubusercontent.com/leleomaster/leo-microservices-dotnet6/master/ShoppingImages/11_mars.jpg",
                CategoryName = "T-Shirt 5"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
