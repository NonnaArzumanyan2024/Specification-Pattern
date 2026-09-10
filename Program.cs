using SimpleSpecification.Data;
using SimpleSpecification.Models;
using SimpleSpecification.Services;
using SimpleSpecification.Specifications;

var products = ProductData.GetProducts();

var activeSpecification =
    new ActiveProductSpecification();

var inactiveSpecification =
    new InactiveProductSpecification();

var expensiveSpecification =
    new ExpensiveProductSpecification();

var cheapSpecification =
    new CheapProductSpecification();

var priceRangeSpecification =
    new PriceRangeSpecification(20000, 100000);

var activeService =
    new ProductService(activeSpecification);

var activeProducts = activeService.GetProducts(products);

Console.WriteLine();
Console.WriteLine("=== Active Products ===");

foreach (var product in activeProducts)
{
    Console.WriteLine($"{product.Name} - {product.Price}");
}

var inactiveService =
    new ProductService(inactiveSpecification);

var inactiveProducts =
    inactiveService.GetProducts(products);

Console.WriteLine();
Console.WriteLine("=== Inactive Products ===");

foreach (var product in inactiveProducts)
{
    Console.WriteLine($"{product.Name} - {product.Price}");
}

var expensiveService =
    new ProductService(expensiveSpecification);

var expensiveProducts =
    expensiveService.GetProducts(products);

Console.WriteLine();
Console.WriteLine("=== Expensive Products ===");

foreach (var product in expensiveProducts)
{
    Console.WriteLine($"{product.Name} - {product.Price}");
}

var cheapService =
    new ProductService(cheapSpecification);

var cheapProducts =
    cheapService.GetProducts(products);

Console.WriteLine();
Console.WriteLine("=== Cheap Products ===");

foreach (var product in cheapProducts)
{
    Console.WriteLine($"{product.Name} - {product.Price}");
}

var priceRangeService =
    new ProductService(priceRangeSpecification);

var priceRangeProducts =
    priceRangeService.GetProducts(products);

Console.WriteLine();
Console.WriteLine("=== Products From 20000 To 100000 ===");

foreach (var product in priceRangeProducts)
{
    Console.WriteLine($"{product.Name} - {product.Price}");
}

var activeAndExpensiveSpecification =
    new AndSpecification(
        activeSpecification,
        expensiveSpecification);

var activeAndExpensiveService =
    new ProductService(activeAndExpensiveSpecification);

var activeAndExpensiveProducts =
    activeAndExpensiveService.GetProducts(products);

Console.WriteLine();
Console.WriteLine("=== Active AND Expensive Products ===");

foreach (var product in activeAndExpensiveProducts)
{
    Console.WriteLine($"{product.Name} - {product.Price}");
}

var activeOrCheapSpecification =
    new OrSpecification(
        activeSpecification,
        cheapSpecification);

var activeOrCheapService =
    new ProductService(activeOrCheapSpecification);

var activeOrCheapProducts =
    activeOrCheapService.GetProducts(products);

Console.WriteLine();
Console.WriteLine("=== Active OR Cheap Products ===");

foreach (var product in activeOrCheapProducts)
{
    Console.WriteLine($"{product.Name} - {product.Price}");
}

var notActiveSpecification =
    new NotSpecification(activeSpecification);

var notActiveService =
    new ProductService(notActiveSpecification);

var notActiveProducts =
    notActiveService.GetProducts(products);

Console.WriteLine();
Console.WriteLine("=== NOT Active Products ===");

foreach (var product in notActiveProducts)
{
    Console.WriteLine($"{product.Name} - {product.Price}");
}