using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Viziofilm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		//VIDEO 2 28 min....... a mettre dans une fonction a appeler au demarrage de l'application
		//var builder = new HostBuilder()
		//	 .ConfigureServices((hostContext, services) =>
		//	 {
		//		 services.AddDbContext<ViziofilmContext>(options => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ViziofilmDB;Trusted_Connection=True;"));
		//		 services.AddSingleton<ClientForm>();
		//		 services.AddLogging(configure => configure.AddConsole());
		//		 services.AddScoped<IFilmRepository, FilmRepository>();
		//		 services.AddScoped<IViziofilmService, ViziofilmService>();

		//	 });

		//var host = builder.Build();
		//using(var serviceScope = host.Services.CreateScope())
		//          {
		//              var services = serviceScope.ServiceProvider;
		//              try
		//              {
		//                  var forms = services.GetRequiredService<ClientForm>();
		//           Application.Run(forms);
		//              }
		//              catch(Exception ex)
		//              {
		//                  Console.WriteLine("Error");
		//              }
		//          }

	}

}
