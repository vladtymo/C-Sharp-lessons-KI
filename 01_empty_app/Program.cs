internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.MapGet("/about", () => "About Page!");

        app.MapGet("/address", () => "Address Page!");

        app.MapGet("/increase", async (http) =>
        {
            int number = int.Parse(http.Request.Query["number"]);
            await http.Response.WriteAsync($"Next number: {number + 1}");
        });

        app.Run();
    }
}