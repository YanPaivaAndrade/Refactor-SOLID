using Alura.LeilaoOnline.WebApp.Dados.Daos;
using Alura.LeilaoOnline.WebApp.Dados.DaosImp;
using Alura.LeilaoOnline.WebApp.Services.Servicos;
using Alura.LeilaoOnline.WebApp.Services.ServicosImp;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.LeilaoOnline.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILeilaoDao, LeilaoDao>();
            services.AddTransient<ICategoriaDao, CategoriaDao>();
            services.AddTransient<IAdminService, AdminExclusaoLogicaService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddDbContext<AppDbContext>();
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => 
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
