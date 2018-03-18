using System.Data.Entity;
using Vidly.Models;

namespace Vidly
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
            : base("name=MovieContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<MemberShipType> MemberShipTypes { get; set; }
        // public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Customer>()

                .HasRequired(t => t.MemberShipType);

            // modelBuilder.Entity<Customer>().HasRequired(m => m.MemberShipType).WithRequiredPrincipal();






        }
    }
}
