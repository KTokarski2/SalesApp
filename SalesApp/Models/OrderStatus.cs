using System.ComponentModel.DataAnnotations;

namespace SalesApp.Models;

public class OrderStatus
{
    [Key]
    public int OrderStatusID { get; set; }
    public string Name { get; set; }
    public virtual List<Order> Orders { get; set; } = new List<Order>();
}