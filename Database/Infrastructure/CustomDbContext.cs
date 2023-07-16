using Abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Infrastructure;

public partial class CustomDbContext : DbContext
{
    public CustomDbContext(DbContextOptions<CustomDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Person> Person { get; set; }

    public virtual DbSet<Address> Address { get; set; }

    public virtual DbSet<Accreditation> Accreditation { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");
            entity.HasKey(person => person.Id);
            entity.HasOne(person => person.Address)
                  .WithOne(address => address.Person)
                  .HasForeignKey<Person>("AddressId");

            entity.HasOne(person => person.Accreditation)
                  .WithOne(accreditation => accreditation.Person)
                  .HasForeignKey<Person>("AccreditationId");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");
            entity.HasKey(address => address.Id);
        });

        modelBuilder.Entity<Accreditation>(entity =>
        {
            entity.ToTable("Accreditation");
            entity.HasKey(accreditation => accreditation.Id);
        });
    }
}