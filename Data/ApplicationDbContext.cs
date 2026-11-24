using Lapichka.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lapichka.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Species> Species => Set<Species>();
    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<AdoptionRequest> AdoptionRequests => Set<AdoptionRequest>();
    public DbSet<VetProcedure> VetProcedures => Set<VetProcedure>();
    public DbSet<VolunteerApplication> VolunteerApplications => Set<VolunteerApplication>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Видовете са с уникално име и не могат да се изтрият, ако има животни от тях
        builder.Entity<Species>()
            .HasIndex(s => s.Name)
            .IsUnique();

        builder.Entity<Animal>()
            .HasOne(a => a.Species)
            .WithMany(s => s.Animals)
            .HasForeignKey(a => a.SpeciesId)
            .OnDelete(DeleteBehavior.Restrict);

        // При изтриване на животно се трият и неговите процедури и заявки
        builder.Entity<VetProcedure>()
            .HasOne(p => p.Animal)
            .WithMany(a => a.VetProcedures)
            .HasForeignKey(p => p.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<AdoptionRequest>()
            .HasOne(r => r.Animal)
            .WithMany(a => a.AdoptionRequests)
            .HasForeignKey(r => r.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<AdoptionRequest>()
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<AdoptionRequest>()
            .HasOne(r => r.ProcessedBy)
            .WithMany()
            .HasForeignKey(r => r.ProcessedById)
            .OnDelete(DeleteBehavior.Restrict);

        // Един потребител – най-много една активна (нова) заявка за едно и също животно
        builder.Entity<AdoptionRequest>()
            .HasIndex(r => new { r.UserId, r.AnimalId })
            .IsUnique()
            .HasFilter($"[Status] = {(int)AdoptionStatus.New}");

        builder.Entity<VolunteerApplication>()
            .HasOne(v => v.User)
            .WithMany()
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Един потребител – само една кандидатура за доброволец със статус „нова“
        builder.Entity<VolunteerApplication>()
            .HasIndex(v => v.UserId)
            .IsUnique()
            .HasFilter($"[Status] = {(int)VolunteerStatus.New}");
    }
}
