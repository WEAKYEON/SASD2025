using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassDesign;

public class ClassDesignTest
{

    public void Run()
    {
        ProductTest();
        //SimpleTest();
        //JsonTest();
        //ImmutableTest();
    }

    void ProductTest()
    {
        var p = new Product { Name = "Noodle", Quantity = 3, Price = 40.50m };
        Console.WriteLine(p);
    }

    void SimpleTest()
    {
        Console.WriteLine(Math.Sin(Math.PI / 6));
        // var sine = angle.Sin();

        var text = File.ReadAllText(@".                                                                                                                                                                             0.
C:\Windows\win.ini");
        Console.WriteLine(text);
    }

    void JsonTest()
    {
        var c1 = new Customer()
        {
            FirstName = "John",
            LastName = "Black",
            DateOfBirth = new DateOnly(1990, 2, 6)
        };
        Console.WriteLine("c1:   " + c1);

        var json = JsonSerializer.Serialize(c1);
        Console.WriteLine("Json: " + json);

        Customer c2 = JsonSerializer.Deserialize<Customer>(json)!;
        Console.WriteLine("c2:   " + c2);

        Customer c3 = new Customer(c2) { FirstName = "Mary" };
        Console.WriteLine("c3:   " + c3);
    }

    void ImmutableTest()
    {
        var name = "John";
        name = "Mary";
        name = "John " + name;
        name = name.Substring(0, 2);
        Console.WriteLine(name);

        DateOnly date = new(2026, 1, 1);
        // ไม่มี method ใดๆ สามารถแก้ไขค่าฟิลด์ภายในได้ หลังจากสร้าง object ขึ้นแล้ว
        var date2 = date.AddDays(15); // เป็นการสร้าง date object ใหม่
        Console.WriteLine(date2);
    }
}
