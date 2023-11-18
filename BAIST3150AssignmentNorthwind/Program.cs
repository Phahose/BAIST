namespace BAIST3150AssignmentNorthwind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var app = builder.Build();


            // Configure the HTTP request pipeline
            app.UseRouting();

            app.MapControllers();
            app.Run();
        }
    }
}