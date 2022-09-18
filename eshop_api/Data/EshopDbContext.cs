using eshop_api.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eshop_api.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
public class EshopDbContext:DbContext
{
    public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer($"Server=tcp:lucasguo811.database.windows.net,1433;Initial Catalog=eshop;Persist Security Info=False;User ID={Encoding.UTF8.GetString(Convert.FromBase64String(Key.User))};Password={Encoding.UTF8.GetString(Convert.FromBase64String(Key.Psw))};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    // }
}




