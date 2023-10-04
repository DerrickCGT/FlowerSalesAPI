using Microsoft.EntityFrameworkCore;
using FlowerSales.Services;

namespace FlowerSales.Models
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEF>().HasData(
                new CategoryEF { Id = 1, CategoryName = "Bouquetes" },
                new CategoryEF { Id = 2, CategoryName = "Box Flowers" },
                new CategoryEF { Id = 3, CategoryName = "Wrapps" },
                new CategoryEF { Id = 4, CategoryName = "Single Flower" },
                new CategoryEF { Id = 5, CategoryName = "Additional" });

            modelBuilder.Entity<ProductEF>().HasData(
                new ProductEF { Id = 1, CategoryId = 1, Name = "Flowers in the city", StoreLocation = "Canning Vale", PostCode = 6155, Price = 68, IsAvailable = true },
                new ProductEF { Id = 2, CategoryId = 1, Name = "Gerberas", StoreLocation = "Willeton", PostCode = 6155, Price = 35, IsAvailable = true },
                new ProductEF { Id = 3, CategoryId = 1, Name = "Aziatic Lilies", StoreLocation = "Palmyra", PostCode = 6123, Price = 33, IsAvailable = true },
                new ProductEF { Id = 4, CategoryId = 1, Name = "European Lilies", StoreLocation = "Melville", PostCode = 6145, Price = 125, IsAvailable = true },
                new ProductEF { Id = 5, CategoryId = 1, Name = "Chrisantemum", StoreLocation = "Canninghton", PostCode = 6112, Price = 60, IsAvailable = true },
                new ProductEF { Id = 6, CategoryId = 1, Name = "Alstroemeria", StoreLocation = "Waikiki", PostCode = 6112, Price = 95, IsAvailable = true },
                new ProductEF { Id = 7, CategoryId = 1, Name = "Snapdragon small", StoreLocation = "Tuart Hill", PostCode = 6112, Price = 65, IsAvailable = true },
                new ProductEF { Id = 8, CategoryId = 1, Name = "V-Crocus", StoreLocation = "Willeton", PostCode = 6113, Price = 65, IsAvailable = true },
                new ProductEF { Id = 9, CategoryId = 1, Name = "Crocus", StoreLocation = "Armadale", PostCode = 6114, Price = 17, IsAvailable = true },
                new ProductEF { Id = 10, CategoryId = 2, Name = "Calla Lily", StoreLocation = "Aubin Grove", PostCode = 6115, Price = 99, IsAvailable = true },
                new ProductEF { Id = 11, CategoryId = 2, Name = "Geranium small", StoreLocation = "Darch", PostCode = 6116, Price = 0, IsAvailable = false },
                new ProductEF { Id = 12, CategoryId = 2, Name = "Grunge Skater Jeans", StoreLocation = "Jonndana", PostCode = 6117, Price = 68, IsAvailable = true },
                new ProductEF { Id = 13, CategoryId = 2, Name = "Geranium Large", StoreLocation = "Joonedaloop", PostCode = 6112, Price = 125, IsAvailable = true },
                new ProductEF { Id = 14, CategoryId = 2, Name = "Stretchy Dance Pants", StoreLocation = "GEralton", PostCode = 6118, Price = 55, IsAvailable = true },
                new ProductEF { Id = 15, CategoryId = 2, Name = "Alstroemeria", StoreLocation = "Piara Waters", PostCode = 6121, Price = 22, IsAvailable = false },
                new ProductEF { Id = 16, CategoryId = 2, Name = "Gerberas", StoreLocation = "Byford", PostCode = 6132, Price = 95, IsAvailable = true },
                new ProductEF { Id = 17, CategoryId = 2, Name = "Marigold", StoreLocation = "Dianella", PostCode = 6342, Price = 17, IsAvailable = true },
                new ProductEF { Id = 18, CategoryId = 3, Name = "Azalea", StoreLocation = "Leong", PostCode = 6123, Price = 2.8M, IsAvailable = true },
                new ProductEF { Id = 19, CategoryId = 3, Name = "Lemon-LAzalea", StoreLocation = "Fremantle", PostCode = 6124, Price = 2.8M, IsAvailable = true },
                new ProductEF { Id = 20, CategoryId = 3, Name = "Zinnia", StoreLocation = "BEaconsfield", PostCode = 6125, Price = 2.8M, IsAvailable = false },
                new ProductEF { Id = 21, CategoryId = 3, Name = "Peach Zinnia", StoreLocation = "North Freo", PostCode = 6126, Price = 2.8M, IsAvailable = true },
                new ProductEF { Id = 22, CategoryId = 3, Name = "Raspberry Zinnia", StoreLocation = "Munster", PostCode = 6127, Price = 2.8M, IsAvailable = true },
                new ProductEF { Id = 23, CategoryId = 3, Name = "Snapdragon big", StoreLocation = "Coogee", PostCode = 6128, Price = 2.8M, IsAvailable = true },
                new ProductEF { Id = 24, CategoryId = 4, Name = " Petunia", StoreLocation = "South Freo", PostCode = 6129, Price = 24.99M, IsAvailable = true },
                new ProductEF { Id = 25, CategoryId = 5, Name = "Dahlia (long lasting)", StoreLocation = "City", PostCode = 6112, Price = 9.99M, IsAvailable = true },
                new ProductEF { Id = 26, CategoryId = 5, Name = "Dahlia", StoreLocation = "West Perth", PostCode = 6130, Price = 12.49M, IsAvailable = true },
                new ProductEF { Id = 27, CategoryId = 5, Name = "Orchid domestic", StoreLocation = "East Perth", PostCode = 6131, Price = 13.99M, IsAvailable = true },
                new ProductEF { Id = 28, CategoryId = 5, Name = "Orchid Expensive", StoreLocation = "Bentley", PostCode = 6132, Price = 12.49M, IsAvailable = true },
                new ProductEF { Id = 29, CategoryId = 5, Name = "Marigold", StoreLocation = "Carslie", PostCode = 6133, Price = 9.99M, IsAvailable = true },
                new ProductEF { Id = 30, CategoryId = 5, Name = "Gardenia type C", StoreLocation = "Lathlain", PostCode = 6134, Price = 11.99M, IsAvailable = true },
                new ProductEF { Id = 31, CategoryId = 5, Name = "Gardenia type-B", StoreLocation = "Booragoon", PostCode = 6135, Price = 12.99M, IsAvailable = true },
                new ProductEF { Id = 32, CategoryId = 5, Name = "Gardenia", StoreLocation = "Applecross", PostCode = 6136, Price = 9.99M, IsAvailable = true },
                new ProductEF { Id = 33, CategoryId = 5, Name = "Calla Lily", StoreLocation = "Rockyngham", PostCode = 6001, Price = 12.49M, IsAvailable = true });
        }

    } 
}
