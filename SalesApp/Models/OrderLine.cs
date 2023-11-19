using System.ComponentModel.DataAnnotations;

namespace SalesApp.Models;

public class OrderLine
{
    [Key]
    public int OrderLineID { get; set; }
    public virtual Product Product { get; set; }
    public int ProductID { get; set; }
    public virtual Order Order { get; set; }
    public int OrderID { get; set; }
    public int Quantity { get; set; }
}