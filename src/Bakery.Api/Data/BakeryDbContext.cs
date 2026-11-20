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
    }
}