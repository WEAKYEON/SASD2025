

namespace EntityFramework1;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public List<Address> Addresses { get; set; } = new ();

    public override string ToString() => $"{Id}:{FirstName} {LastName}";

    public Customer() { }
    public Customer(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}

public class Address
{
    public int Id { get; set; }
    public int CustId { get; set; }
    public string AddrLine { get; set; } = "";
    public string Province { get; set; } = "";
    public override string ToString() => $"{Id}:{CustId}:{AddrLine}, {Province}";

    public Address() { }

    public Address(int id, int custId, string addrLine, string province)
    {
        Id = id;
        CustId = custId;
        AddrLine = addrLine;
        Province = province;
    }
}

