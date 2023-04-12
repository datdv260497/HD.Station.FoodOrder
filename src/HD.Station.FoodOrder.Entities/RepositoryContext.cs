using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HD.Station.FoodOrder.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HD.Station.FoodOrder.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Menu>? Menus { get; set; }
        public DbSet<Dish>? Dishes { get; set; }
        public DbSet<MenuDetail>? MenuDetails { get; set; }
        public DbSet<HD.Station.FoodOrder.Entities.Models.FoodOrder>? FoodOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Menu>(entiny =>
            {
                entiny.ToTable("Menu", "Order");
            });

            modelBuilder.Entity<MenuDetail>().HasKey(mn => new { mn.MenuId, mn.DishId });

            modelBuilder.Entity<MenuDetail>(entiny =>
            {
                entiny.ToTable("MenuDetail", "Order");
                entiny.HasOne<Menu>(s => s.Menu)
                .WithMany(n => n.MenuDetails)
                .HasForeignKey(s => s.MenuId);


            });

            modelBuilder.Entity<MenuDetail>(entiny =>
            {
                entiny.HasOne<Dish>(s => s.Dish)
                .WithMany(n => n.MenuDetails)
                .HasForeignKey(s => s.DishId);


            });

            modelBuilder.Entity<Dish>(entiny =>
            {
                entiny.ToTable("Dish", "Order");
            });


            modelBuilder.Entity<HD.Station.FoodOrder.Entities.Models.FoodOrder>(entiny =>
            {
                entiny.ToTable("FoodOrder", "Order");
            });
        }
    }
}
