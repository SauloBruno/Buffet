using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Buffet.Models.Acesso;
using Buffet.Models.Buffet.Cliente;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Buffet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("BuffetDb"))
            );

            //configurar o controle de acesso do usuario
            //Informar a aplicação queremos usar o indentity
            //é mecessario informar para aplicação onde ele vai buscar/armazenar os dados do usuario 
            //options são usados para configurar as nuancias do login do usuario, tbm serve para determinar
            //as exigencias nedessarias para o cadastro de um usuario
            services.AddIdentity<Usuario, Papel>(options =>
            {
                
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;

            }).AddEntityFrameworkStores<DatabaseContext>();

            //ajustar cofigurações a nivel de cokie e session
            services.ConfigureApplicationCookie(options =>
            {
                //loginPath serve para definir onde os usuarios que não tem autorização para acessar uma
                //pagina vão cair 
                options.LoginPath = "/Acesso/Login";
            });
            
            services.AddTransient<ClienteService>();
            services.AddTransient<AcessoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Acesso}/{action=Login}/{param?}"
                );
            });
        }
    }
}