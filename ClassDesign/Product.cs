using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesign;

public class Product
{
    public required string Name { get; init; }
    public required int Quantity { get; init; }
    public required decimal Price { get; init; }

    // Todo#1: create computed property "TotalPrice" as decimal
    public decimal TotalPrice => Price * Quantity;
    
    // Todo#2: override ToString() method
    public override string ToString()
    {
        // :C คือการจัดรูปแบบเป็นสกุลเงิน (Currency)
        return $"Name: {Name} | Price: {Price} | Quantity: {Quantity}  | Total: {TotalPrice}";
    }
}
