using Microsoft.EntityFrameworkCore;
using TargetCustomer___MVC.Models;

namespace TargetCustomer___MVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Consultoria> Consultorias { get; set;}
        public DbSet<AvaliacaoConsultoria> AvaliacaoConsultorias { get; set;}
    }
}
