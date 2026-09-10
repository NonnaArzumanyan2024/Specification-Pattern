# Simple Specification Pattern

## About the Project

This project is a simple C# console application created to learn and demonstrate the **Specification Pattern**.

The project uses products as an example.

Each product has:

* Id
* Name
* Price
* IsActive

The main goal of the project is to understand how business rules can be separated into independent **Specification** classes and how these specifications can be combined to create more complex rules.

---

## What is the Specification Pattern?

The **Specification Pattern** is a behavioral design pattern used to represent a business rule or condition as a separate object.

Instead of putting many conditions directly inside a service or business logic method, we create separate Specification classes.

For example, instead of writing:

```csharp
if (product.IsActive && product.Price > 100000)
{
    // ...
}
```

we can create two separate specifications:

```text
ActiveProductSpecification
ExpensiveProductSpecification
```

and combine them:

```text
Active AND Expensive
```

This makes the code easier to understand, reuse, test, and extend.

---

## Why do we use the Specification Pattern?

In real applications, business rules can become complicated.

For example, an application may need rules such as:

* Product must be active.
* Product must be inactive.
* Product must be expensive.
* Product must be cheap.
* Product price must be between two values.
* Product must be active AND expensive.
* Product must be active OR cheap.
* Product must NOT be active.

If all these conditions are written directly inside services, the service can become difficult to maintain.

The Specification Pattern moves these rules into separate classes.

This gives each class a clear responsibility.

---

## Main Idea

The main idea of this project is:

```text
Business Rule
     ↓
Specification
     ↓
true / false
```

A Specification answers one simple question:

> Does this object satisfy the rule?

The common interface is:

```csharp
public interface ISpecification<T>
{
    bool IsSatisfiedBy(T item);
}
```

The important method is:

```csharp
IsSatisfiedBy()
```

It returns:

* `true` if the object satisfies the specification.
* `false` if the object does not satisfy the specification.

---

# Project Structure

```text
SimpleSpecification
│
├── Models
│   └── Product.cs
│
├── Data
│   └── ProductData.cs
│
├── Specifications
│   ├── ISpecification.cs
│   ├── ActiveProductSpecification.cs
│   ├── InactiveProductSpecification.cs
│   ├── ExpensiveProductSpecification.cs
│   ├── CheapProductSpecification.cs
│   ├── PriceRangeSpecification.cs
│   ├── AndSpecification.cs
│   ├── OrSpecification.cs
│   └── NotSpecification.cs
│
├── Services
│   └── ProductService.cs
│
├── Program.cs
└── SimpleSpecification.csproj
```

---

# Project Components

## 1. Product Model

The `Product` class represents a product in the application.

```csharp
public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public bool IsActive { get; set; }
}
```

The product contains the data that our specifications will check.

For example:

```text
Name: Laptop
Price: 150000
IsActive: true
```

---

# 2. ProductData

`ProductData.cs` contains test products.

The data is separated from `Program.cs` so that the main program does not become too large.

Example:

```csharp
new Product
{
    Id = 1,
    Name = "Laptop",
    Price = 150000,
    IsActive = true
}
```

The project contains 20 test products.

This allows us to test different specifications with the same data.

---

# 3. ISpecification

`ISpecification.cs` contains the common interface for all specifications.

```csharp
public interface ISpecification<T>
{
    bool IsSatisfiedBy(T item);
}
```

The interface defines a common contract.

Every specification must implement:

```csharp
IsSatisfiedBy()
```

This means that `ProductService` does not need to know the details of every specification.

It only knows that a specification can answer:

```text
Is this product accepted by the rule?
```

---

# 4. ActiveProductSpecification

This specification checks whether a product is active.

```csharp
public bool IsSatisfiedBy(Product product)
{
    return product.IsActive;
}
```

The rule is:

```text
IsActive == true
```

Example:

```text
Laptop → true → accepted
Keyboard → false → rejected
```

---

# 5. InactiveProductSpecification

This specification checks whether a product is inactive.

```csharp
public bool IsSatisfiedBy(Product product)
{
    return !product.IsActive;
}
```

The rule is:

```text
IsActive == false
```

---

# 6. ExpensiveProductSpecification

This specification checks whether a product costs more than 100000.

```csharp
public bool IsSatisfiedBy(Product product)
{
    return product.Price > 100000;
}
```

The rule is:

```text
Price > 100000
```

For example:

```text
Laptop - 150000 → accepted
Mouse - 5000 → rejected
```

---

# 7. CheapProductSpecification

This specification checks whether a product costs 10000 or less.

```csharp
public bool IsSatisfiedBy(Product product)
{
    return product.Price <= 10000;
}
```

The rule is:

```text
Price <= 10000
```

---

# 8. PriceRangeSpecification

This specification checks whether the product price is inside a specific range.

```csharp
public PriceRangeSpecification(
    decimal minPrice,
    decimal maxPrice)
{
    _minPrice = minPrice;
    _maxPrice = maxPrice;
}
```

For example:

```csharp
new PriceRangeSpecification(20000, 100000);
```

means:

```text
20,000 <= Price <= 100,000
```

This specification is reusable because the minimum and maximum prices can be changed.

For example:

```csharp
new PriceRangeSpecification(10000, 50000);
```

or:

```csharp
new PriceRangeSpecification(50000, 200000);
```

The same class can be used for different price ranges.

---

# 9. AndSpecification

`AndSpecification` combines two specifications.

The result is `true` only when **both specifications are true**.

The main logic is:

```csharp
return _left.IsSatisfiedBy(product) &&
       _right.IsSatisfiedBy(product);
```

Example:

```text
Active AND Expensive
```

This means:

```text
Is the product active?
        AND
Is the product expensive?
```

Example:

```text
Laptop
Active → true
Expensive → true
Result → true
```

But:

```text
Gaming Chair
Active → false
Expensive → true
Result → false
```

Therefore, only products satisfying both rules are returned.

---

# 10. OrSpecification

`OrSpecification` combines two specifications using OR.

The main logic is:

```csharp
return _left.IsSatisfiedBy(product) ||
       _right.IsSatisfiedBy(product);
```

The result is `true` when **at least one specification is true**.

Example:

```text
Active OR Cheap
```

This means:

```text
Is the product active?
        OR
Is the product cheap?
```

Only one condition needs to be true.

---

# 11. NotSpecification

`NotSpecification` reverses the result of another specification.

The main logic is:

```csharp
return !_specification.IsSatisfiedBy(product);
```

For example:

```text
NOT Active
```

If:

```text
Active → true
```

then:

```text
NOT Active → false
```

If:

```text
Active → false
```

then:

```text
NOT Active → true
```

This allows us to create negative business rules without creating a completely new specification class.

---

# Specification Composition

One of the most useful features of this project is **Specification Composition**.

Composition means combining existing specifications to create a new rule.

For example:

```text
Active
   +
Expensive
   ↓
AND
   ↓
Active AND Expensive
```

The important point is that we do not need to create a new class such as:

```text
ActiveAndExpensiveProductSpecification
```

We can reuse existing specifications.

Example:

```csharp
var activeAndExpensiveSpecification =
    new AndSpecification(
        activeSpecification,
        expensiveSpecification);
```

This makes the rules reusable.

---

# AND, OR and NOT

The project demonstrates three important ways of composing specifications.

## AND

```text
Active AND Expensive
```

Both conditions must be true.

```text
true AND true = true
true AND false = false
false AND true = false
false AND false = false
```

---

## OR

```text
Active OR Cheap
```

At least one condition must be true.

```text
true OR true = true
true OR false = true
false OR true = true
false OR false = false
```

---

## NOT

```text
NOT Active
```

The result is reversed.

```text
NOT true = false
NOT false = true
```

---

# ProductService

`ProductService` is responsible for filtering products using a specification.

The service receives a specification through its constructor:

```csharp
public ProductService(ISpecification<Product> specification)
{
    _specification = specification;
}
```

Then it checks every product:

```csharp
if (_specification.IsSatisfiedBy(product))
{
    result.Add(product);
}
```

The important point is that `ProductService` does not know the specific business rule.

It does not need to know whether the rule is:

```text
Active
Inactive
Expensive
Cheap
Price Range
AND
OR
NOT
```

It only knows that it receives an `ISpecification<Product>`.

---

# Dependency Injection

This project also demonstrates a simple form of **Dependency Injection**.

For example:

```csharp
var activeService =
    new ProductService(activeSpecification);
```

The `ProductService` receives its dependency from outside.

The service depends on:

```csharp
ISpecification<Product>
```

instead of depending directly on:

```csharp
ActiveProductSpecification
```

or:

```csharp
ExpensiveProductSpecification
```

This makes the service more flexible and easier to change.

---

# Separation of Responsibilities

The project separates different responsibilities.

```text
Product
    ↓
stores product data

ProductData
    ↓
provides test data

Specification
    ↓
checks business rules

ProductService
    ↓
filters products

Program
    ↓
runs the application and displays results
```

Each part has a clear responsibility.

This makes the code easier to understand and maintain.

---

# Advantages of the Specification Pattern

## 1. Reusability

A specification can be reused in different places.

For example:

```csharp
var expensiveSpecification =
    new ExpensiveProductSpecification();
```

The same specification can be used by different services.

---

## 2. Separation of Business Rules

Each business rule has its own class.

For example:

```text
ActiveProductSpecification
ExpensiveProductSpecification
CheapProductSpecification
```

This keeps business logic organized.

---

## 3. Better Readability

Instead of a long condition:

```csharp
if (product.IsActive &&
    product.Price > 100000)
```

we can write:

```csharp
Active AND Expensive
```

using Specification objects.

The business rule becomes easier to understand.

---

## 4. Easy Composition

Existing specifications can be combined.

For example:

```text
Active AND Expensive
```

or:

```text
Active OR Cheap
```

or:

```text
NOT Active
```

More complex rules can also be built from smaller specifications.

---

## 5. Easier Testing

Each specification can be tested independently.

For example, we can test:

```text
ActiveProductSpecification
```

without testing the whole application.

We can give it a product and check whether the result is correct.

---

## 6. Easier Maintenance

If the business rule changes, we can change the related specification instead of searching through a large service class.

For example, if the definition of an expensive product changes from:

```text
Price > 100000
```

to:

```text
Price > 150000
```

we only need to change the `ExpensiveProductSpecification`.

---

## 7. Less Duplicate Logic

Without specifications, the same condition may be repeated in different services.

For example:

```csharp
product.IsActive
```

could appear in many places.

With a specification, the rule is defined in one place.

---

# Disadvantages and Considerations

The Specification Pattern is useful, but it should not automatically be used for every small condition.

For a very simple application, creating many classes can sometimes make the project larger than necessary.

For example, creating a separate class for every tiny condition may add unnecessary complexity.

The pattern is most useful when:

* business rules are important,
* rules are reused,
* rules need to be combined,
* rules are becoming complex,
* rules need independent testing,
* the application needs clean separation of business logic.

---

# Example Flow

The application follows this general flow:

```text
Program.cs
     ↓
ProductData
     ↓
List<Product>
     ↓
ProductService
     ↓
ISpecification<Product>
     ↓
IsSatisfiedBy(product)
     ↓
true / false
     ↓
Filtered products
     ↓
Console output
```

---

# Example: Active AND Expensive

The application can combine two existing specifications:

```csharp
var activeAndExpensiveSpecification =
    new AndSpecification(
        activeSpecification,
        expensiveSpecification);
```

Then the service uses the combined specification:

```csharp
var activeAndExpensiveService =
    new ProductService(activeAndExpensiveSpecification);
```

The result contains products that satisfy both rules.

Example output:

```text
=== Active AND Expensive Products ===
Laptop - 150000
Tablet - 120000
Smartphone - 220000
Graphics Card - 300000
```

---

# Example: Active OR Cheap

The application can also combine specifications using OR:

```csharp
var activeOrCheapSpecification =
    new OrSpecification(
        activeSpecification,
        cheapSpecification);
```

This returns products where at least one of the conditions is satisfied.

---

# Example: NOT Active

The application can reverse a specification:

```csharp
var notActiveSpecification =
    new NotSpecification(activeSpecification);
```

This returns products that are not active.

---

# How to Run the Project

## Requirements

You need:

* .NET SDK
* A code editor such as Visual Studio Code
* Terminal

---

## Run the Project

Open the project folder in the terminal:

```bash
cd SimpleSpecification
```

Then run:

```bash
dotnet run
```

The application will display the results of the different specifications.

---

# Build the Project

To check whether the project compiles successfully:

```bash
dotnet build
```

If the build is successful, the project is compiled without errors.

---

# Technologies Used

* C#
* .NET
* Object-Oriented Programming
* Interfaces
* Generics
* Dependency Injection
* Specification Pattern
* Console Application

---

# Learning Goals

This project was created to practice:

* C# classes and objects
* Interfaces
* Generics
* Constructors
* Encapsulation
* Separation of responsibilities
* Dependency Injection
* Business rules
* Specification Pattern
* Specification Composition
* AND / OR / NOT logic
* Basic project organization
* Git and GitHub workflow

---

# Conclusion

The main purpose of this project is to demonstrate how business rules can be represented as independent Specification objects.

Instead of placing all conditions inside one large method, the application separates the rules into small and reusable classes.

The most important idea is:

```text
One business rule
        ↓
One specification
        ↓
Reusable
        ↓
Composable
```

Specifications can then be combined:

```text
Active
   AND
Expensive
```

or:

```text
Active
   OR
Cheap
```

or:

```text
NOT Active
```

This approach helps keep business logic clean, reusable, testable, and easier to maintain.
