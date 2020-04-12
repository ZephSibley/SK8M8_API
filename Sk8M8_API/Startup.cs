using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SignalRChat.Hubs;
using Sk8M8_API.DataClasses;
using Sk8M8_API.Models;
using System;
using System.Text;
using System.Threading.Tasks;

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

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false; // make this true for use in production
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                // Allow JWT Auth handler to read access tokens
                // on incoming WebSocket/Server-Sent Event requests
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/hubs/chat")))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            }).AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = _env.IsDevelopment()
                  ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.None;
            });


            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.HttpOnly = HttpOnlyPolicy.Always;
                options.Secure = _env.IsDevelopment()
                  ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
            });

            services.AddScoped<Services.ISessionManagementService, Services.SessionManagementService>();

            services.AddCors(options =>
            {
                options.AddPolicy(AllowWebClientOrigin,
                builder =>
                {
                    builder.WithOrigins("https://sk8m8.co", "https://www.sk8m8.co")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            services.AddSignalR();
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
            // app.UseCors(AllowWebClientOrigin);
            app.UseCookiePolicy();
            app.UseAuthentication();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapControllerRoute("default", "{controller=Account}/{action=Me}/{id?}");
            });
        }
    }
}
