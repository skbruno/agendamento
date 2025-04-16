using Microsoft.EntityFrameworkCore;
using Agendamento_app.Models;

namespace Agendamento_app.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User>? User { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
    }
}
