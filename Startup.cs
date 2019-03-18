using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contact_api.Repositories;
using Contact_Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace contact_api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Mvc
            services.AddMvc();
            
            //Add Injeção de dependência
            services.AddScoped<AppDataContext, AppDataContext>();
            services.AddTransient<IContactTypeRepository, ContactTypeRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();

            // Add Swagger for api documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Contact API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact API");
            });

            
        }
    }
}
