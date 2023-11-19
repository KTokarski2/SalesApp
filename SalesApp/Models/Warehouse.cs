using System.ComponentModel.DataAnnotations;

namespace SalesApp.Models;

public class Warehouse
{
    [Key]
    public int WarehouseID { get; set; }
    public string Name { get; set; }
    public virtual Product Product { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
}