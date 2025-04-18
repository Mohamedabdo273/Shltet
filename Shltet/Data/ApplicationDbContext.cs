using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shelter.Models;
using Shltet.Modles;
using System.Reflection.Emit;

namespace Shltet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<Pet> Pets { get; set; }
        DbSet<PetCategory> PetCategories { get; set; }
        DbSet<Modles.Shelter> Shelters { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<SupportRequest> SupportRequests { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PetCategory>()
    .HasOne(p => p.Shelter)
    .WithMany(s => s.Categories)
    .HasForeignKey(p => p.ShelterId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Pet>()
    .HasOne(p => p.ShelterAccount)
    .WithMany(s => s.Pets)
    .HasForeignKey(p => p.ShelterAccountId)
    .OnDelete(DeleteBehavior.Restrict); // أو NoAction


        }


    }
}
