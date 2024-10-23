// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using ConsoleAppSemaine3.Models;
using Microsoft.EntityFrameworkCore;
using static System.Console;




WriteLine("Numéro d'exercice à exécuter (Exemple : B1)");
string? exerciceNumber = ReadLine();

if (exerciceNumber is not null)
{
    switch (exerciceNumber)
    {
        case "B1":
            ExB1();
            break;
        case "B2":
            ExB2();
            break;
        case "B3":
            ExB3();
            break;
        case "B4":
            ExB4();
            break;
        case "B5":
            ExB5();
            break;
        case "B6":
            ExB6();
            break;
        case "B7":
            ExB7();
            break;
        case "C1":
            ExC1();
            break;
        case "D1":
            ExD1();
            break;
        case "E1":
            ExE1();
            break;
    }
}

static void ExB1()
{

    WriteLine("B1 - Recherche clients par ville");
    WriteLine("Entrez le nom de la ville : ");
    string city = ReadLine();

    if (city != null) {

        using (NorthwindContext context = new NorthwindContext())
        {


            var curstomers = from Customer customer in context.Customers
                             where customer.City == city
                             select new
                             {
                                 CustomerId = customer.CustomerId,
                                 CustomerName = customer.CompanyName
                             };

            foreach (var customer in curstomers)
            {
                WriteLine("{0} : {1}", customer.CustomerId, customer.CustomerName);
            }
        }
    }
}


static void ExB2()
{
    WriteLine("Exericcie B2");

    using (NorthwindContext context = new NorthwindContext())
    {
        IQueryable<Category> categorys = from category in context.Categories
                                         where category.CategoryName == "Beverages" || category.CategoryName == "Condiments"
                                         select category;


        foreach (var category in categorys)
        {
            WriteLine("Category : " + category.CategoryName);

            foreach (Product product in category.Products)
            {
                WriteLine("Nom du produit : " + product.ProductName);
            }
        }
    }
}

static void ExB3()
{
    WriteLine("Exercice B3");

    using(NorthwindContext context = new NorthwindContext())
    {
        IQueryable<Category> categories = from category in context.Categories
                                          .Include("Products")
                                          where category.CategoryName == "Beverages" || category.CategoryName == "Condiments"
                                          select category;


        foreach(var category in categories)
        {
            WriteLine("Catergory : " + category.CategoryName);

            foreach(Product product in category.Products)
            {
                WriteLine("Produit : " + product.ProductName);
            }
        }
    }
}

static void ExB4()
{
    WriteLine("Exercice B4");
    WriteLine("Donnez l'id du client : ");
    string id_client = ReadLine();

    using (NorthwindContext context = new NorthwindContext())
    {
        var request = from commande in context.Orders
                      where commande.OrderDate != null && commande.CustomerId == id_client && commande.ShippedDate != null
                      orderby (commande.OrderDate) descending
                      select new
                      {
                          Customer = commande.CustomerId,
                          DateCommande = commande.OrderDate,
                          DateLivraison = commande.ShippedDate
                      };

        foreach (var order in request)
        {
            WriteLine("CustomerId : " + order.Customer + "OrderDate : " + order.DateCommande + "ShippedDate : " + order.DateLivraison);
        }
    }
}


static void ExB5()
{
    WriteLine("Exercice B5");

    using (NorthwindContext context = new NorthwindContext())
    {
        var request = from order in context.OrderDetails.AsEnumerable()
                      orderby order.ProductId
                      group order by (order.ProductId);


        foreach (IGrouping<int, OrderDetail> details in request)
        {
            WriteLine(details.Key + "-------->" + details.Sum(detail => detail.Quantity * detail.UnitPrice));
        }
                      

    }
}

static void ExB6()
{
    WriteLine("Exercice B6");

    using (NorthwindContext context = new NorthwindContext())
    {
        var request = from employee in context.Employees
                      where employee.Territories.Any(t => t.Region.RegionDescription.Equals("Western"))
                      select employee;


        WriteLine("Liste des emplyés pour la region Western");

        foreach (var employee in request)
        {
            WriteLine("Patron : " + employee.FirstName);
        }
    }
}

static void ExB7()
{
    WriteLine("Exercice B7");

    using (NorthwindContext context = new NorthwindContext())
    {
        var territories = (from Employee employee in context.Employees
                          where employee.LastName.Equals("Suyama")
                          select employee.ReportsToNavigation.Territories).SingleOrDefault();


        WriteLine("Les territoires gérés par le supérieur de Suyama");

        foreach(Territory territory in territories)
        {
            WriteLine(territory.TerritoryDescription);
        }
    }
}


static void ExC1()
{
    using(NorthwindContext context = new NorthwindContext())
    {
        var request = from Customer customer in context.Customers
                      select customer;


        foreach (var customer1 in request)
        {
            char.ToUpper(customer1.ContactName[0]);
            WriteLine(customer1.ContactName);
        }

        try
        {
            context.SaveChanges();
        }catch (Exception e)
        {
            WriteLine("Erreur" + e.Message);
        }
        WriteLine("Done");
    }
}

static void ExD1()
{
    using (NorthwindContext context = new NorthwindContext())
    {

        WriteLine("Veuillez saisir un nom à donner à la catégorie : ");
        string name = ReadLine();

        Category category = new Category
        {
            CategoryName = name
        };

        context.Categories.Add(category);

        try
        {
            context.SaveChanges();
        }
        catch (Exception e)
        {
            WriteLine("Erreur : " + e.Message);

        }
        WriteLine("Done");
    }
}


static void ExE1()
{
    using(NorthwindContext context = new NorthwindContext())
    {
        var request = from Category category in context.Categories
                      where category.CategoryName == "Ibrahim"
                      select category;


        context.Categories.Remove(request.First());

        try
        {
            context.SaveChanges();
        }
        catch (Exception e)
        {
            WriteLine("Erreur " + e.Message);
        }
    }
}
