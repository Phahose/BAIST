using Microsoft.AspNetCore.Mvc;

namespace ClubBAISTGolfClub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddRazorPages();
            builder.Services.AddSession();


            builder.Services.AddRazorPages().AddRazorPagesOptions(o =>
            {
                o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            });


            var app = builder.Build();

            //Configure the HTTP reqest pipeline
           
            app.UseStaticFiles(); // add for wwroot
            app.UseRouting();
            app.UseSession();
            app.MapRazorPages();

            app.Run();
        }
    }
}
