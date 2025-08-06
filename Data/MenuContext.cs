using Microsoft.EntityFrameworkCore;
using Menu.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
namespace Menu.Data
{
    public class MenuContext : DbContext
    {


        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });

            modelBuilder.Entity<DishIngredient>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(i => i.IngredientId);
            modelBuilder.Entity<Dish>()
                .HasData(
                    new Dish
                    {
                        Id = 1,
                        Name = "Margherita Pizza",
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQmomF1DksRYo9MLTC6zi2qx1XjX7R5PSqPYQ&s",
                        Price = 8.99
                    }

                );
            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new Ingredient
                    {
                        Id = 1,
                        Name = "Tomato Sauce"
                    },
                     new Ingredient
                     {
                         Id = 2,
                         Name = "Mozzarella Cheese"
                     }
                );
            modelBuilder.Entity<DishIngredient>()
                .HasData(
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 1
                    },
                    new DishIngredient
                    {
                        DishId = 1,
                        IngredientId = 2
                    }
                );
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }

    }
}