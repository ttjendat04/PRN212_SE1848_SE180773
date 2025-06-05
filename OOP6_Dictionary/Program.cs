using System.Text;
using OOP6_Dictionary;

Console.OutputEncoding = Encoding.UTF8;

Category c1 = new Category();
c1.Id = 1;
c1.Name = "Soft drink";

Product p1 = new Product();
p1.Id = 1;
p1.Name = "Sting";
p1.Quantity = 100;
p1.Price = 12;
c1.AddProduct(p1);

Product p2 = new Product();
p2.Id = 2;
p2.Name = "Pepsi";
p2.Quantity = 103;
p2.Price = 12;
c1.AddProduct(p2);

Product p3 = new Product();
p3.Id = 3;
p3.Name = "Coca";
p3.Quantity = 200;
p3.Price = 10;
c1.AddProduct(p3);

Product p4 = new Product();
p4.Id = 4;
p4.Name = "Xa Xi";
p4.Quantity = 70;
p4.Price = 9;
c1.AddProduct(p4);

Product p5 = new Product();
p5.Id = 5;
p5.Name = "Red Bull";
p5.Quantity = 50;
p5.Price = 13;
c1.AddProduct(p5);

Console.WriteLine("====Caterory Information====");
Console.WriteLine(c1);
Console.WriteLine("====Products List====");
c1.PrintAllProducts();

double min_price = 10;
double max_price = 20;
Dictionary<int, Product> products_by_price =
    c1.FilterProductByPrice(min_price, max_price);
Console.WriteLine($"List of product has price from {min_price} to {max_price}");
foreach (KeyValuePair<int, Product> kvp in products_by_price)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sorted_products = c1.SortProductByPrice();
Console.WriteLine("====List of products sorted by price====");
foreach (KeyValuePair<int, Product> kvp in sorted_products)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sorted_complex_product = c1.SortComplex();
Console.WriteLine("====List of products sorted by price====");
foreach (KeyValuePair<int, Product> kvp in sorted_complex_product)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

p5.Name = "Fanta";
p5.Price = 8;
p5.Quantity = 90;
bool ret = c1.UpdateProduct(p5);
Console.WriteLine("====List of products after update====");
c1.PrintAllProducts();

int id = 5;
ret = c1.RemoveProduct(id);
if (ret == false)
    Console.WriteLine($"Product with id {id} not found");
else
{
    Console.WriteLine($"Product with id {id} has been removed");
    Console.WriteLine("====List of products after remove====");
    c1.PrintAllProducts();
}

int NumberOfDeleted = c1.DeleteProductByPrice(9, 10);
Console.WriteLine($"Deleted {NumberOfDeleted} in price limit: "); 
Console.WriteLine("====List of products after delete by price====");
c1.PrintAllProducts();

int NumberDeleted = c1.DeleteProductByQuantity(70, 100);
Console.WriteLine($"Deleted {NumberDeleted} in Quantity limit: ");
Console.WriteLine("====List of products after delete by price====");
c1.PrintAllProducts();



LinkedList<Category> categories = new LinkedList<Category>();
categories.AddLast(c1);

Category c2 = new Category();
c2.Id = 2;
c2.Name = "Beer";

c2.AddProduct(new Product { Id = 6, Name = "Tiger", Quantity = 50, Price = 20 });
c2.AddProduct(new Product { Id = 7, Name = "Heineken", Quantity = 60, Price = 25 });
c2.AddProduct(new Product { Id = 8, Name = "Saigon", Quantity = 70, Price = 22 });

categories.AddFirst(c2);
Console.WriteLine("====List of categories====");
foreach (Category c in categories)
{
    Console.WriteLine(c);
    Console.WriteLine("--------------------------");
    c.PrintAllProducts();
    Console.WriteLine("--------------------------");
}    