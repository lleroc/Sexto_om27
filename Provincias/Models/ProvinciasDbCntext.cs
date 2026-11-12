namespace Provincias.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ProvinciasDbCntext : DbContext
    {
        public ProvinciasDbCntext(DbContextOptions db):base(db)
        {}

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Canton> Cantones { get; set; }

    }
}
