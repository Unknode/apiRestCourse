using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ApiRest.Model.Context;
using ApiRest.Business;
using ApiRest.Repository;
using ApiRest.Business.Interfaces;
using ApiRest.Repository.Generic;
using ApiRest.Data.Converter.Contract;
using ApiRest.Data.Converter.Implementations;
using ApiRest.Model;
using ApiRest.Data.VO;

namespace ApiRest
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
            services.AddControllers();

            string connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            services.AddScoped(typeof(IParser<Person, PersonVO>), typeof(PersonParser));
            services.AddScoped(typeof(IParser<PersonVO, Person>), typeof(PersonParser));
            services.AddScoped(typeof(IParser<Book, BookVO>), typeof(BookParser));
            services.AddScoped(typeof(IParser<BookVO, Book>), typeof(BookParser));
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection)); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiRest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiRest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
