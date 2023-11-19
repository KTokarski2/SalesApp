using System.ComponentModel.DataAnnotations;

namespace SalesApp.Models;

public class Invoice
{
    [Key]
    public int InvoiceID { get; set; }
    public virtual List<Order> Orders { get; set; } = new List<Order>();
}