using DbFirst.Data;
using DbFirst.Models;
using DbFirst.Repo;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace DbFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddOData(options =>
            options.Select().Filter().OrderBy().Expand().Count().AddRouteComponents("odata",GetEdmModel()));

            // dbcontext
            builder.Services.AddDbContext<AppDbContext>();

            // repos
            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<ILoanRepo, LoanReo>();

            // OData

         
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

            static IEdmModel GetEdmModel()
            {
                var builder = new ODataConventionModelBuilder();
                builder.EntitySet<Book>(nameof(Book));
                builder.EntitySet<Loan>(nameof(Loan));
                return builder.GetEdmModel();
            }

        }
    }
}
