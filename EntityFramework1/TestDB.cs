using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework1;

public class TestDB
{

    public void Run()
    {
        using var context = new MyDbContext();

        ClearAndInit(context);
        AddCustomer(context);
        RemoveCustomer(context);
        UpdateCustomer(context);
        Read(context);
    }

    void Read(MyDbContext context)
    {
        Console.WriteLine("\n----Whole Table----");
        context.Customers.ToList().ForEach(Console.WriteLine);
        Console.WriteLine("----");
        //context.  // todo

        Console.WriteLine("\n----Query some rows----");
        var list = context.Customers.Where(c => c.Id < 3).ToList();
       //ar list = context.Customers.OrderBy(c => c.FirstName).ToList();
        list.ForEach(Console.WriteLine);

        Console.WriteLine("\n----Query single row----");
        Console.WriteLine();//todo
    }

    void ClearAndInit(MyDbContext context)
    {
        context.Database.BeginTransaction();

        context.Addresses.ExecuteDelete();
        context.Customers.ExecuteDelete();

        context.Customers.Add(new Customer(1, "John", "Black"));
        context.Customers.Add(new Customer(2, "Mary", "Pink"));

        context.Addresses.Add(new Address(51, 1, "4444, Main Road", "Bangkok"));
        context.Addresses.Add(new Address(52, 1, "3333, Main Road", "Bangkok"));
        context.Addresses.Add(new Address(53, 2, "5555, Sub Road", "Chonburi"));

        context.SaveChanges();
        context.Database.CommitTransaction();
    }

    void AddCustomer(MyDbContext context)
    {
        var c = new Customer(3, "Jane", "White");
        // todo
    }

    void RemoveCustomer(MyDbContext context)
    {
        var c = new Customer() { Id = 3 };
        // todo
    }

    void UpdateCustomer(MyDbContext context)
    {
        // var cust = context.Customers.Where( // todo
        // var cust2 = (from c in context.Customers where c.Id == 3 select c).Single();

        // todo
    }
}
