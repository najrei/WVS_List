namespace WVS_List.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Produkt> Produkts { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasOptional(e => e.Group)
                .WithRequired(e => e.Admin);

            modelBuilder.Entity<Group>()
                .HasOptional(e => e.List)
                .WithRequired(e => e.Group);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Groups)
                .Map(m => m.ToTable("UserGroups").MapLeftKey("GroupID").MapRightKey("UserID"));

            modelBuilder.Entity<List>()
                .HasMany(e => e.Produkts)
                .WithMany(e => e.Lists)
                .Map(m => m.ToTable("ProduktLists"));

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Admin)
                .WithRequired(e => e.User);
        }
    }
}
