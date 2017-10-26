using MySql.Data.Entity;
using PosRi.DataAccess.Model;
using System.Data.Entity;

namespace PosRi.DataAccess.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PosRiContext : DbContext
    {
        public PosRiContext() : base("name=mysqlConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CashFound> CashFounds { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<CashRegisterMove> CashRegisterMoves { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CustomerDebt> CustomerDebts { get; set; }
        public DbSet<CustomerPayment> CustomerPayments { get; set; }
        public DbSet<InventoryProduct> InventoryProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductHeader> ProductHeaders { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<PurchaseHeader> PurchaseHeaders { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<SaleHeader> SaleHeaders { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<VendorDebt> VendorDebts { get; set; }
        public DbSet<VendorPayment> VendorPayments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(ur =>
                {
                    ur.MapLeftKey("UserId");
                    ur.MapRightKey("RoleId");
                    ur.ToTable("UserRoles");
                });

            modelBuilder.Entity<Vendor>()
                .HasMany(u => u.Brands)
                .WithMany(brand => brand.Vendors)
                .Map(ur =>
                {
                    ur.MapLeftKey("VendorId");
                    ur.MapRightKey("BrandId");
                    ur.ToTable("VendorBrands");
                });
        }
    }
}
