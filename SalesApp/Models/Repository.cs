using Microsoft.EntityFrameworkCore;

namespace SalesApp.Models;

public class Repository : DbContext
{
    public Repository()
    {
        
    }

    public Repository(DbContextOptions<Repository> options) : base(options)
    {
        
    }
    
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Invoice> Invoices { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderLine> OrderLines { get; set; }
    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => new { e.CustomerID }).HasName("Customer_pk");
            entity.ToTable("Customer");
            entity.Property(e => e.Name);
            entity.Property(e => e.Address1);
            entity.Property(e => e.Address2);
            entity.Property(e => e.Mail);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceID }).HasName("Invoice_pk");
            entity.ToTable("Invoice");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => new { e.OrderID }).HasName("Order_pk");
            entity.ToTable("Order");
            entity.Property(e => e.TotalAmount).HasColumnType("money");

            entity
                .HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CustomerID)
                .OnDelete(DeleteBehavior.Cascade) // Czy to odpowiednie zachowanie dla tego przypadku?
                .HasConstraintName("Customer_Orders");

            entity
                .HasOne(e => e.Invoice)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.InvoiceID)
                .OnDelete(DeleteBehavior.Cascade) // Czy to odpowiednie zachowanie dla tego przypadku?
                .HasConstraintName("Invoice_Orders");

            entity
                .HasOne(e => e.OrderStatus)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.OrderStatusID)
                .OnDelete(DeleteBehavior.Restrict) // Czy to odpowiednie zachowanie dla tego przypadku?
                .HasConstraintName("OrderStatus_Orders");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => new { e.OrderLineID }).HasName("OrderLine_pk");
            entity.ToTable("OrderLine");
            entity.Property(e => e.Quantity);

            entity
                .HasOne(e => e.Order)
                .WithMany(e => e.OrderLines)
                .HasForeignKey(e => e.OrderID)
                .OnDelete(DeleteBehavior.Cascade) // Czy to odpowiednie zachowanie dla tego przypadku?
                .HasForeignKey("Order_OrderLines");

            entity
                .HasOne(e => e.Product)
                .WithMany(e => e.OrderLines)
                .HasForeignKey(e => e.ProductID)
                .OnDelete(DeleteBehavior.Restrict) // Czy to odpowiednie zachowanie dla tego przypadku?
                .HasForeignKey("Product_OrderLines");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => new { e.OrderStatusID }).HasName("OrderStatus_pk");
            entity.ToTable("OrderStatus");
            entity.Property(e => e.Name);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => new { e.ProductID }).HasName("Product_pk");
            entity.ToTable("Product");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => new { e.WarehouseID }).HasName("Warehouse_pk");
            entity.ToTable("Warehouse");
            entity.Property(e => e.Name);
            entity.Property(e => e.Quantity);

            entity
                .HasOne(e => e.Product)
                .WithMany(e => e.Warehouses)
                .HasForeignKey(e => e.ProductID)
                .OnDelete(DeleteBehavior.Restrict) // Czy to odpowiednie zachowanie dla tego przypadku?
                .HasConstraintName("Product_Warehouses");
        });
    }
}