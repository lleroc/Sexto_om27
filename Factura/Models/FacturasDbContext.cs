using Microsoft.EntityFrameworkCore;
namespace Factura.Models
{
    public class FacturasDbContext : DbContext
    {
        public DbSet<Factura.Models.FacturaModel> FacturaModel { get; set; } = default!;
        public FacturasDbContext(DbContextOptions op):base(op)
        {
            
        }
    }
}
