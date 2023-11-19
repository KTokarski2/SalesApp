using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Models;

public class Product
{
    [Key]
    public int ProductID { get; set; }
    
    [StringLength(200, ErrorMessage = "Max length for product name is 200")]
    public string Name { get; set; }
    
    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    
    public virtual List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
    
    public virtual List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}