using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicwall.Models;
using medicwall.Repositories.Contract;
using medicwall.Repositories.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace medicwall
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
            services.AddMvc().
                SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(Options => {
                    var resolver = Options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                })
                .AddJsonOptions(options => 
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddDbContext<medicwallContext>(op => op.UseNpgsql("Host=localhost;Database=medicwall;Username=postgres;Password=admin"));
            services.AddScoped<IMedicwallRepository<Adress>, AdressRepository>();
            services.AddScoped<IMedicwallRepository<User>, UserRepository>();
            services.AddScoped<IMedicwallRepository<ConfDoctor>, ConfDoctorRepository>();
            services.AddScoped<IMedicwallRepository<Document>, DocumentRepository>();
            services.AddScoped<IMedicwallRepository<ConfPatient>, ConfPatientRepository>();
            services.AddScoped<IMedicwallRepository<Contact>, ContactRepository>();
            services.AddScoped<IMedicwallRepository<DocsecRel>, DocsecRelRepository>();
            services.AddScoped<IMedicwallRepository<Expertise>, ExpertiseRepository>();
            services.AddScoped<IMedicwallRepository<Schedule>, ScheduleRepository>();
            services.AddScoped<IMedicwallRepository<City>, CityRepository>();
            services.AddScoped<IMedicwallRepository<Role>, RoleRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
