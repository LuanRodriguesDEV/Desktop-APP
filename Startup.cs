using Microsoft.EntityFrameworkCore;
using MonowProject.Context;
using MonowProject.Services;


namespace MonowProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<UsuariosServices>();
            services.AddScoped<ComandasServices>();
            services.AddScoped<ProdutosServices>();
            services.AddScoped<CategoriasServices>();
            services.AddScoped<CaixasServices>();
            services.AddScoped<PedidosServices>();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });


        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }

    }
}
