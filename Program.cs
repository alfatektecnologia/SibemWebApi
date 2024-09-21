
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SibemWebApi.Data;
using SibemWebApi.Repositorios;
using SibemWebApi.Repositorios.Interfaces;
using System.Text;
//using Google.Cloud.FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;

// Replace with your Firebase project credentials
var credential = GoogleCredential.FromFile("C:\\Users\\user\\Downloads\\sibem-9cd5f-firebase-adminsdk-q6xmf-b581e86998.json");
FirebaseApp.Create(new AppOptions() { Credential = credential });


namespace SibemWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var secretKey = "252167c1-ed92-4dd4-a5ee-7b6cf1525d2b";
            var builder = WebApplication.CreateBuilder(args);
                        
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Sibem API", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "JWT Autenticação",
                    Description = "Entre com o JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                config.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securitySchema, new string[] { } } });
            });

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SibemDbContext>(
                    options => options.UseMySql(builder.Configuration.GetConnectionString("Database"), new MySqlServerVersion(new Version(8, 0, 23))));

            builder.Services.AddScoped<IIgrejaRepositorio, IgrejaRepositorio>();
            builder.Services.AddScoped<IInventarioRepositorio, InventarioRepositorio>();
            builder.Services.AddScoped<IBemRepositorio, BemRepositorio>();
            builder.Services.AddScoped<IFotosRepositorio, FotosRepositorio>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true, //token terá um tempo de validade
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Alfatek Tecnologia Ltda",
                    ValidAudience = "SibemWebApi",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            var app = builder.Build();

            app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
