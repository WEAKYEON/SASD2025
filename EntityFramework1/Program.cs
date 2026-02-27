using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFramework1;

internal class Program
{
    static void Main(string[] args)
    {
        new TestDB().Run();
    }
}
