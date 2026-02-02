using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Context;
internal class ApplicationDbContext : DbContext, IUnitOfWork
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=OMER;Initial Catalog=DomainDrivenDesignDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(s => s.Name).HasConversion(name => name.Value, value => new(value));
        modelBuilder.Entity<User>().Property(s => s.Email).HasConversion(name => name.Value, value => new(value));
        modelBuilder.Entity<User>().Property(s => s.Password).HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<User>().OwnsOne(p => p.Address);

        modelBuilder.Entity<Category>().Property(p => p.Name).HasConversion(name => name.Value, value => new(value));
        modelBuilder.Entity<Product>().Property(p => p.Name).HasConversion(name => name.Value, value => new(value));
        modelBuilder.Entity<Product>().OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.Currency).HasConversion(currency => currency.Code, code => Currency.CheckCurrencyType(code));

            priceBuilder.Property(p => p.Amount).HasColumnType("money");
        });

        modelBuilder.Entity<OrderLine>().OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.Currency).HasConversion(currency => currency.Code, code => Currency.CheckCurrencyType(code));

            priceBuilder.Property(p => p.Amount).HasColumnType("money");
        });


    }
}
