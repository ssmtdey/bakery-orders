using Bakery.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Api.Data;

public class BakeryDbContext : DbContext
{
    public BakeryDbContext(DbContextOptions<BakeryDbContext> options) : base(options) {}

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<MenuItem> MenuItems => Set<MenuItem>();

    public DbSet<SizeOption> SizeOptions => Set<SizeOption>();

    public DbSet<SizeOptionPart> SizeOptionParts => Set<SizeOptionPart>();

    public DbSet<Filling> Fillings => Set<Filling>();

    public DbSet<ExtraType> ExtraTypes => Set<ExtraType>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderLine> OrderLines => Set<OrderLine>();

    public DbSet<LineExtra> LineExtras => Set<LineExtra>();

    public DbSet<WeekBooking> WeekBookings => Set<WeekBooking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasIndex(o => o.PickupDate);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WeekBooking>().HasKey(w => w.BakeDate);

        modelBuilder.Entity<SizeOptionPart>()
            .HasOne(p => p.SizeOption).WithMany(s => s.Parts)
            .HasForeignKey(p => p.SizeOptionId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<SizeOptionPart>()
            .HasOne(p => p.PartSizeOption).WithMany()
            .HasForeignKey(p => p.PartSizeOptionId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderLine>()
            .HasOne(l => l.Order)
            .WithMany(o => o.Lines)
            .HasForeignKey(l => l.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderLine>()
            .HasOne(l => l.SizeOption)
            .WithMany()
            .HasForeignKey(l => l.SizeOptionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<LineExtra>()
            .HasOne(e => e.ExtraType)
            .WithMany()
            .HasForeignKey(e => e.ExtraTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderLine>()
            .HasMany(l => l.Fillings)
            .WithMany();

        modelBuilder.Entity<Customer>().Property(c => c.Name).HasMaxLength(100);

        modelBuilder.Entity<Customer>().Property(c => c.Handle).HasMaxLength(100);

        modelBuilder.Entity<Customer>().Property(c => c.Phone).HasMaxLength(20);

        modelBuilder.Entity<MenuItem>().Property(m => m.Name).HasMaxLength(100);

        modelBuilder.Entity<SizeOption>().Property(s => s.Name).HasMaxLength(100);

        modelBuilder.Entity<Filling>().Property(f => f.Name).HasMaxLength(100);

        modelBuilder.Entity<ExtraType>().Property(e => e.Name).HasMaxLength(100);

        modelBuilder.Entity<Order>().Property(o => o.DeclineNote).HasMaxLength(500);

        modelBuilder.Entity<OrderLine>().Property(l => l.OccasionDetail).HasMaxLength(100);

        modelBuilder.Entity<OrderLine>().Property(l => l.Inscription).HasMaxLength(60);

        modelBuilder.Entity<OrderLine>().Property(l => l.ColourTheme).HasMaxLength(100);

        modelBuilder.Entity<OrderLine>().Property(l => l.DesignNotes).HasMaxLength(1000);

        modelBuilder.Entity<OrderLine>().Property(l => l.InspoLink).HasMaxLength(500);

        modelBuilder.Entity<Customer>().Property(c => c.Channel).HasConversion<string>();

        modelBuilder.Entity<Order>().Property(o => o.Status).HasConversion<string>();

        modelBuilder.Entity<Order>().Property(o => o.DeclineReason).HasConversion<string>();

        modelBuilder.Entity<Order>().Property(o => o.PaymentMethod).HasConversion<string>();

        modelBuilder.Entity<OrderLine>().Property(l => l.Flavour).HasConversion<string>();

        modelBuilder.Entity<OrderLine>().Property(l => l.Occasion).HasConversion<string>();

        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, Name = "Cupcakes" },
            new MenuItem { Id = 2, Name = "Bentocake" },
            new MenuItem { Id = 3, Name = "Round cake" },
            new MenuItem { Id = 4, Name = "Heart cake" });

        modelBuilder.Entity<Filling>().HasData(
            new Filling { Id = 1, Name = "Chocolate", IsActive = true },
            new Filling { Id = 2, Name = "Caramel", IsActive = true },
            new Filling { Id = 3, Name = "Lemon curd", IsActive = true },
            new Filling { Id = 4, Name = "Oreo", IsActive = true },
            new Filling { Id = 5, Name = "Lotus biscoff", IsActive = true },
            new Filling { Id = 6, Name = "Kinderbueno", IsActive = true });

        modelBuilder.Entity<ExtraType>().HasData(
            new ExtraType { Id = 1, Name = "Topper" },
            new ExtraType { Id = 2, Name = "Fondant figure" },
            new ExtraType { Id = 3, Name = "Fresh flowers" },
            new ExtraType { Id = 4, Name = "Chocolates" },
            new ExtraType { Id = 5, Name = "Fake flowers" });
        
        modelBuilder.Entity<SizeOption>().HasData(
            new SizeOption { Id = 1, MenuItemId = 1, Name = "1 cupcake", Tiers = 1, MaxFillings = 1, OvenUnits = 1, BasePricePence = 350, IsActive = true },
            new SizeOption { Id = 2, MenuItemId = 1, Name = "6 cupcakes", Tiers = 1, MaxFillings = 6, OvenUnits = 0, BasePricePence = 2500, IsActive = true },
            new SizeOption { Id = 3, MenuItemId = 1, Name = "12 cupcakes", Tiers = 1, MaxFillings = 6, OvenUnits = 0, BasePricePence = 4500, IsActive = true },
            new SizeOption { Id = 4, MenuItemId = 2, Name = "Bentocake", Tiers = 1, MaxFillings = 1, OvenUnits = 5, BasePricePence = 2500, IsActive = true },
            new SizeOption { Id = 5, MenuItemId = 2, Name = "Bentocake & 2 cupcakes", Tiers = 1, MaxFillings = 3, OvenUnits = 0, BasePricePence = 3500, IsActive = true },
            new SizeOption { Id = 6, MenuItemId = 2, Name = "Bentocake & 5 cupcakes", Tiers = 1, MaxFillings = 6, OvenUnits = 0, BasePricePence = 5000, IsActive = true },
            new SizeOption { Id = 7, MenuItemId = 2, Name = "Bentocake & 8 cupcakes", Tiers = 1, MaxFillings = 6, OvenUnits = 0, BasePricePence = 6000, IsActive = true },
            new SizeOption { Id = 8, MenuItemId = 3, Name = "Round cake 8-10 servings", Tiers = 1, MaxFillings = 1, OvenUnits = 20, BasePricePence = 6500, IsActive = true },
            new SizeOption { Id = 9, MenuItemId = 3, Name = "Round cake 12-15 servings", Tiers = 1, MaxFillings = 1, OvenUnits = 20, BasePricePence = 8000, IsActive = true },
            new SizeOption { Id = 10, MenuItemId = 3, Name = "Round cake 18-22 servings", Tiers = 1, MaxFillings = 1, OvenUnits = 30, BasePricePence = 12000, IsActive = true },
            new SizeOption { Id = 11, MenuItemId = 3, Name = "Round cake 24-27 servings", Tiers = 1, MaxFillings = 1, OvenUnits = 30, BasePricePence = 15000, IsActive = true },
            new SizeOption { Id = 12, MenuItemId = 4, Name = "Heart cake 10-15 servings", Tiers = 1, MaxFillings = 1, OvenUnits = 20, BasePricePence = 7500, IsActive = true },
            new SizeOption { Id = 13, MenuItemId = 4, Name = "Heart cake 20-25 servings", Tiers = 1, MaxFillings = 1, OvenUnits = 30, BasePricePence = 14500, IsActive = true },
            new SizeOption { Id = 14, MenuItemId = 3, Name = "Round cake 30-35 servings", Tiers = 2, MaxFillings = 2, OvenUnits = 0, BasePricePence = 20000, IsActive = true },
            new SizeOption { Id = 15, MenuItemId = 3, Name = "Round cake 40-45 servings", Tiers = 2, MaxFillings = 2, OvenUnits = 0, BasePricePence = 25000, IsActive = true });

        modelBuilder.Entity<SizeOptionPart>().HasData(
            new SizeOptionPart { Id = 1, SizeOptionId = 2, PartSizeOptionId = 1, Quantity = 6 },
            new SizeOptionPart { Id = 2, SizeOptionId = 3, PartSizeOptionId = 1, Quantity = 12 },
            new SizeOptionPart { Id = 3, SizeOptionId = 5, PartSizeOptionId = 4, Quantity = 1 },
            new SizeOptionPart { Id = 4, SizeOptionId = 5, PartSizeOptionId = 1, Quantity = 2 },
            new SizeOptionPart { Id = 5, SizeOptionId = 6, PartSizeOptionId = 4, Quantity = 1 },
            new SizeOptionPart { Id = 6, SizeOptionId = 6, PartSizeOptionId = 1, Quantity = 5 },
            new SizeOptionPart { Id = 7, SizeOptionId = 7, PartSizeOptionId = 4, Quantity = 1 },
            new SizeOptionPart { Id = 8, SizeOptionId = 7, PartSizeOptionId = 1, Quantity = 8 },
            new SizeOptionPart { Id = 9, SizeOptionId = 14, PartSizeOptionId = 8, Quantity = 1 },
            new SizeOptionPart { Id = 10, SizeOptionId = 14, PartSizeOptionId = 10, Quantity = 1 },
            new SizeOptionPart { Id = 11, SizeOptionId = 15, PartSizeOptionId = 9, Quantity = 1 },
            new SizeOptionPart { Id = 12, SizeOptionId = 15, PartSizeOptionId = 11, Quantity = 1 });
    }
}