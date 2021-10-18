using AdessoRideShare.Repository.Context.Concrete;
using AdessoRideShare.API.Extensions.Startup;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdessoRideShare.API
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
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));

            services.AddMediatR(typeof(Startup));
            services.RegisterServices();
            services.AddDbContext<RideShareDbContext>(options => options.UseInMemoryDatabase("RideShare"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using(var service =app.ApplicationServices.CreateScope())
            {
                var context = service.ServiceProvider.GetService<RideShareDbContext>();
                context.Database.EnsureCreated();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.DocumentTitle = "Ride Share doküman";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Adesso RideShare");
            });
        }
    }
}
