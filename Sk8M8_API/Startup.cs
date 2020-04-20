using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Sk8M8_API.DataClasses;
using Sk8M8_API.Models;
using System;
using System.Text;

namespace Sk8M8_API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment env
        )
        {
            Configuration = configuration;
            _env = env;
        }
        readonly string AllowWebClientOrigin = "_AllowWebClientOrigin";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
               .AddDbContext<SkateContext>(options =>
                    options.UseNpgsql(
                        Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"),
                        o => o.UseNetTopologySuite()
                    )
                );

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = _env.IsDevelopment();
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddScoped<Services.ISessionManagementService, Services.SessionManagementService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowWebClientOrigin,
                    builder =>
                    {
                        builder.WithOrigins("https://sk8m8.co", "https://www.sk8m8.co")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

            services.AddMvc(o =>
           {
               var policy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()
                   .Build();
               o.Filters.Add(new AuthorizeFilter(policy));
           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            SkateContext context
        )
        {
            context = context ?? throw new ArgumentNullException(nameof(context));
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseCors(AllowWebClientOrigin);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Account}/{action=Me}/{id?}");
            });
        }
    }
}
