using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using Viziofilm;
using Viziofilm.Core.Interfaces;
using Viziofilm.Core.Services;
using Viziofilm.Infrastructure;
using Viziofilm.Infrastructure.Repositories;
using Viziofilm.SharedKernel.Interfaces;
using Viziofilm.Presentation.Services;

namespace Viziofilm
{
	public partial class App : Application
	{
		private readonly IHost _host;
		public App()
		{
			_host = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					ConfigureCoreServices(services);
					ConfigureInfrastructureServices(services);
					ConfigurePresentationServices(services);

					//Fenetre de départ
					services.AddSingleton<Accueil>();
				})
				.Build();
		}
		//Service
		private void ConfigureCoreServices(IServiceCollection services)
		{
			services.AddTransient<IViziofilmService, ViziofilmService>();
		}
		private void ConfigureInfrastructureServices(IServiceCollection services)
		{
			//DbContext
			string connectingString = "Server=(localdb)\\MSSQLLocalDB;Database= ViziofilmDB;Trusted_Connection=True;";
			services.AddDbContext<ViziofilmContext>(options =>
				options.UseSqlServer(connectingString)
			);

			//Repositories
			services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
			services.AddScoped<IFilmRepository, FilmRepository>();
			services.AddScoped<IAdministrateurRepository, AdministrateurRepository>();
			services.AddScoped<IMembreRepository, MembreRepository>();


		}
		//ViewModels
		private void ConfigurePresentationServices(IServiceCollection services)
		{
			services.AddSingleton<INavigationService, NavigationService>();
			services.AddTransient<CatalogueAdministrateur>();
			services.AddTransient<CatalogueMembre>();
			services.AddTransient<Inscription>();
			services.AddTransient<AccueilViewModel>();
			services.AddTransient<InscriptionViewModel>();
			services.AddSingleton<Accueil>();
		}
		//Démarrage de l'interface graphique
		protected override async void OnStartup(StartupEventArgs e)
		{
				await _host.StartAsync();

				var mainWindow = _host.Services.GetRequiredService<Accueil>();
				mainWindow.Show();

				base.OnStartup(e);
		}
		protected override async void OnExit(ExitEventArgs e)
		{
			using (_host)
			{
				await _host.StopAsync();
			}
			base.OnExit(e);
		}
	}
}
