using Microsoft.EntityFrameworkCore;

namespace Myshop.Models
{
    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; } // Add DbSet for CartItem

        // Define CartItem entity
        public class CartItem
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        // Method to add item to cart
        public void AddToCart(int productId, int quantity)
        {
            var existingCartItem = CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                var newCartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                };
                CartItems.Add(newCartItem);
            }
            SaveChanges();
        }

        // Your existing configurations for Product entity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Your entity configurations
        }
    }
}
