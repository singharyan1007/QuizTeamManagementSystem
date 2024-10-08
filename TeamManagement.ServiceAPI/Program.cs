
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TeamManagament.Data;
using TeamManagement.Domain.Repository;

namespace TeamManagement.ServiceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Register the DbContext with dependency injection
            string conStr = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<TeamManageContext>(options =>
            {
                options.UseSqlServer(conStr);
            });

            //Add dependency injection
            builder.Services.AddTransient<ITeamRepository, TeamRepository>();
            builder.Services.AddTransient<IMemberRepository,MemberRepository>();




            builder.Services.AddControllers().AddXmlDataContractSerializerFormatters().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
