using AutoGlass.Domain.Interfaces.Repository;
using AutoGlass.Domain.Interfaces.Services;
using AutoGlass.Infra;
using AutoGlass.Infra.Repositories.Repository;
using AutoGlass.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoGlass.Domain.DTO;
using AutoGlass.Domain.Models;
using AutoGlass.Domain.AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using AutoGlass.Domain.Validations;

namespace AutoGlass
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
            services.AddDbContext<SqlContext>(options => options
                        .UseLazyLoadingProxies()
                        .EnableSensitiveDataLogging()
                        .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), optionsBuilder => optionsBuilder.MigrationsAssembly("AutoGlass.Infra")));

            services.AddValidatorsFromAssemblyContaining<ProdutoValidator>();

            services.AddControllers();

            services.AddFluentValidationAutoValidation();

            var config = new MapperConfiguration(mc =>
            {
                FornecedorMapper.MapearFornecedor(mc);

                ProdutoMapper.MapearProduto(mc);
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddTransient<IValidator<ProdutoDTO>, ProdutoValidator>();
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
        }
    }
}
