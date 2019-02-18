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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           app.UseMvc();
            
        }
    }
}
