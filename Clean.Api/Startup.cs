using System.Reflection;
using AutoMapper;
using Clean.Api.Core.ActionFilters;
using Clean.Api.Core.TypeMappings;
using Clean.Core.DataAccess;
using Clean.Functionality.Users.GetUserById;
using Clean.Infrastructure.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clean.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //This generates User and Service data.  This is not thread safe, but will work fine for demo and example purposes
            services.AddSingleton(new InMemoryData().BuildData());

            //Lasts the lifetime of the request/connection
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();
            
            services.AddControllers()
                .AddJsonOptions(options => { options.JsonSerializerOptions.WriteIndented = false; });

            services.AddMediatR(Assembly.GetAssembly(typeof(GetUserByIdCommand)));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserToUserViewModelConverter)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapControllers();
            });
        }
    }
}