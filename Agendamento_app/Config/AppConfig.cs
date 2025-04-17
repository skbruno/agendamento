using Agendamento_app.Context;
using Agendamento_app.Services;
using Microsoft.EntityFrameworkCore;

namespace Agendamento_app.Config
{
    public class AppConfig
    {
        public static void InitDependencies(WebApplicationBuilder builder)
        {
            try
            {
                DatabaseConfig(builder);
                ServiceConfig(builder);
                MemoryConfig(builder);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar as dependencias {ex.Message}", ex);
            }
        }

        public static void DatabaseConfig(WebApplicationBuilder builder)
        {
            string? mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(Options => Options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
        }

        public static void ServiceConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<AppointmentService>();
            builder.Services.AddScoped<ServiceService>();
            builder.Services.AddSingleton<AuthService>();
        }

        public static void MemoryConfig(WebApplicationBuilder builder)
        {
            //Guardando em cache para poder acessar os dados do usuario como o token em memoria da sessão
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });
        }
    }
}
