using AluraChallenge1.DTO;
using AluraChallenge1.Infra;
using AluraChallenge1.Models;
using AluraChallenge1.Service;
using AluraChallenge1.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AluraChallenge1
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AluraChallenge1", Version = "v1" });
            });

            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Video, CreateVideoDTO>().ReverseMap();
                cfg.CreateMap<Video, UpdateVideoDTO>().ReverseMap();
                cfg.CreateMap<Categoria, CreateCategoriaDTO>().ReverseMap();
                cfg.CreateMap<Categoria, UpdateCategoriaDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            services.AddDbContext<Context>(options => options.UseSqlite(@"Data Source=C:\SQLiteStudio\mydb.db;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AluraChallenge1 v1"));
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
