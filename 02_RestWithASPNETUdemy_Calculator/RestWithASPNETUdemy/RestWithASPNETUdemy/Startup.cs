using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Business.Implementations;
using System;
using System.Collections.Generic;
using Serilog;
using Microsoft.Data.SqlClient;
using RestWithASPNETUdemy.Repository.Generic;
using Microsoft.Net.Http.Headers;
using RestWithASPNETUdemy.Hypermedia.Filters;
using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Enricher;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;
using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Services.Implementations;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace RestWithASPNETUdemy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var tokenConfiguration = new TokenConfigurations();

            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                 Configuration.GetSection("TokenConfiguration")
                ).Configure(tokenConfiguration);

            services.AddSingleton(tokenConfiguration);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenConfiguration.Emissor,
                    ValidAudience = tokenConfiguration.Audiencia,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Segredo))
                };
            });


            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build()
                    );
            });

            services.AddCors(options => 
                            options.AddDefaultPolicy(builders => 
                            builders.AllowAnyOrigin().
                                     AllowAnyMethod().
                                     AllowAnyHeader())
                            );
            services.AddControllers();

            var connection = Configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
            services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connection));

            //if (Environment.IsDevelopment())
            //{
            //    MigrateDatabase(connection);
            //}


            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PessoaEnricher());
            filterOptions.ContentResponseEnricherList.Add(new LivroEnricher());

            services.AddSingleton(filterOptions);

            //Versionar API
            services.AddApiVersioning();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title ="REST API'S DO 0 AO AZURE COM ASP.NET CORE 5",
                    Version= "v1",
                    Description = "REST API'S DO 0 AO AZURE COM ASP.NET CORE 5",
                    Contact = new OpenApiContact 
                    {
                      Name ="Paulo Ricardo",
                      Url = new Uri("https://github.com/prch1")
                    }
                });
            });

            //Injeção de Dependência
            services.AddScoped<IPessoaBusiness, PessoaBusinessImplementation>();
            services.AddScoped<ILivroBusiness, LivroBusinessImplementation>();
            services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new SqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch(Exception ex)
            {
                Log.Error("Database Migration failed",ex);
                throw;
            }
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

            app.UseCors();

            app.UseSwagger();
            
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API'S DO 0 AO AZURE COM ASP.NET CORE 5 - V1");
               });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
