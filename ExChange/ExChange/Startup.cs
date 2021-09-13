using Domain.IServices;
using Domain.Models;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AutoMapperProfiles;

namespace ExChange
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            environment = env;
        }
        public IWebHostEnvironment environment;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            services.AddControllers();
            services.AddDbContext<AppDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=ExChange;Integrated Security=True"));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(x =>
            {
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context => Task.CompletedTask,
                        OnChallenge = context => Task.CompletedTask
                    };
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["BaseUrl"],
                        ValidAudience = Configuration["BaseUrl"],
                        IssuerSigningKey = secretKey,
                        ClockSkew = TimeSpan.Zero
                    };
                });


            //---------------------------------------------swagger
            
                services.AddSwaggerGen(
    c =>
    {
        //c.IncludeXmlComments(@"G:\Project\IOPWebAPI\Domain\Domain.xml");
        //c.EnableAnnotations();
        //c.DocumentFilter<BasePathDocumentFilter>();
        
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme (Example: Bearer 12345abcdef)",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
                      {
                        new OpenApiSecurityScheme
                        {
                          Reference = new OpenApiReference
                            {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                          },
                          new List<string>(){ }
                        }
    });
        var security = new Dictionary<string, IEnumerable<string>>
        {
            // {"Bearer", new string[] {"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjZWUwYTRjNy03MWM0LTQ4OGEtZDljOC0wOGQ4NzViMjViODciLCJqdGkiOiIwOTEyNDM0NjgyNCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJlaHNhbiBqYWxpbHZhbmQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTYwOTc4NDYyMn0.lId6yiQ-j1RevR8TwuPJpbdcGnbW-Vx5J2zAJj5s_ac" }},
        };
    }
    );
            
            //--------------------------------------------------------


            services.AddScoped<ICoinServices, CoinServices>();
            services.AddScoped<ICommentsServices, CommentsServices>();
            services.AddScoped<IConfigurationsServices, ConfigurationServices>();
            services.AddScoped<ILikedServices, LikedServices>();
            services.AddScoped<IPaymentServices, PaymentServices>();
            services.AddScoped<IPostServices, PostServices>();
            services.AddScoped<IRelevanceServices, RelevanceServices>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<ITicketServices, TicketServices>();
            services.AddScoped<ITicketAttachmentsServices, TicketAttachmentServices>();
            services.AddScoped<ITicketDetailsServices, TicketDetailsServices>();
            services.AddScoped<ITicketServices, TicketServices>();
            services.AddScoped<ITradeServices, TradeServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IWalletServices, WalletServices>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IOP Web Api");
                //c.RoutePrefix = "docs";
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
