
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace ShopDb.Models
{
    public partial class ShopdbContext : DbContext
    {
        public ShopdbContext()
        {
        }

        public ShopdbContext(DbContextOptions<ShopdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.Categoryid);

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("categoryname");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Productid);

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Discontinued).HasColumnName("discontinued");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("productname");

                entity.Property(e => e.Unitprice)
                    .HasColumnType("money")
                    .HasColumnName("unitprice");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}