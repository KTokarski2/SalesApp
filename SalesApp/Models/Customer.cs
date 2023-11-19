using System.ComponentModel.DataAnnotations;

namespace SalesApp.Models;

public class Customer
{
    [Key]
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    
    [EmailAddress(ErrorMessage = "Email address is not valid")]
    public string Mail { get; set; }
    
    public virtual List<Order> Orders { get; set; } = new List<Order>();
}