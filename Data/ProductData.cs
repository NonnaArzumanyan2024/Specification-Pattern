using SimpleSpecification.Models;

namespace SimpleSpecification.Data;

public static class ProductData
{
    public static List<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 150000,
                IsActive = true
            },

            new Product
            {
                Id = 2,
                Name = "Mouse",
                Price = 5000,
                IsActive = true
            },

            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Price = 20000,
                IsActive = false
            },

            new Product
            {
                Id = 4,
                Name = "Monitor",
                Price = 80000,
                IsActive = true
            },

            new Product
            {
                Id = 5,
                Name = "Headphones",
                Price = 25000,
                IsActive = true
            },

            new Product
            {
                Id = 6,
                Name = "Webcam",
                Price = 18000,
                IsActive = false
            },

            new Product
            {
                Id = 7,
                Name = "Printer",
                Price = 95000,
                IsActive = true
            },

            new Product
            {
                Id = 8,
                Name = "USB Cable",
                Price = 3000,
                IsActive = true
            },

            new Product
            {
                Id = 9,
                Name = "Tablet",
                Price = 120000,
                IsActive = true
            },

            new Product
            {
                Id = 10,
                Name = "Microphone",
                Price = 35000,
                IsActive = false
            },

            new Product
            {
                Id = 11,
                Name = "Smartphone",
                Price = 220000,
                IsActive = true
            },

            new Product
            {
                Id = 12,
                Name = "Smart Watch",
                Price = 75000,
                IsActive = true
            },

            new Product
            {
                Id = 13,
                Name = "External Hard Drive",
                Price = 45000,
                IsActive = false
            },

            new Product
            {
                Id = 14,
                Name = "SSD",
                Price = 55000,
                IsActive = true
            },

            new Product
            {
                Id = 15,
                Name = "Graphics Card",
                Price = 300000,
                IsActive = true
            },

            new Product
            {
                Id = 16,
                Name = "USB Hub",
                Price = 12000,
                IsActive = true
            },

            new Product
            {
                Id = 17,
                Name = "Gaming Chair",
                Price = 110000,
                IsActive = false
            },

            new Product
            {
                Id = 18,
                Name = "Router",
                Price = 28000,
                IsActive = true
            },

            new Product
            {
                Id = 19,
                Name = "Projector",
                Price = 175000,
                IsActive = false
            },

            new Product
            {
                Id = 20,
                Name = "Mechanical Keyboard",
                Price = 45000,
                IsActive = true
            }
        };
    }
}