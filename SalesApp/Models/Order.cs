using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Models;

public class Order
{
    [Key]
    public int OrderID { get; set; }
    
    public virtual Customer Customer { get; set; }
    
    public int CustomerID { get; set; }
    
    [Column(TypeName = "money")]
    public decimal TotalAmount { get; set; }
    
    public virtual OrderStatus OrderStatus { get; set; }
    public int OrderStatusID { get; set; }
    public virtual Invoice Invoice { get; set; }
    public int InvoiceID { get; set; }
    public virtual List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}