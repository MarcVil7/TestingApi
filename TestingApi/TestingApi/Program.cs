
namespace TestingApi;

public class Program
{
    public static void Main(string[] args)
    {
        try{

        Console.WriteLine("Starting");
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        Console.WriteLine("Buil ");
        var app = builder.Build();

        // Configure the HTTP request pipeline.
       
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/test1", (HttpContext httpContext) =>
        {
            return "test1";
        })
        .WithName("test1")
        .WithOpenApi();

          app.MapGet("/test2", (HttpContext httpContext) =>
        {
            return "test2";
        })
        .WithName("test2")
        .WithOpenApi();

        app.Run();

        }
        catch(Exception exc){
            var msg = exc.Message;
            Console.WriteLine(msg);
        }
    }
}
