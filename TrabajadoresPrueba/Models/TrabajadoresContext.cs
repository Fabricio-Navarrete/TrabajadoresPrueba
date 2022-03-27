using Microsoft.EntityFrameworkCore;

namespace TrabajadoresPrueba.Models
{
    public class TrabajadoresContext : DbContext
    { 
        public TrabajadoresContext(DbContextOptions<TrabajadoresContext>options):base(options)
        {

        }

        public DbSet<Trabajadores> Trabajadores{ get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Distrito> Distrito { get; set; }

    }
}
