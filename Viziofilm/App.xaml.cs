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
using Viziofilm.Presentation.ViewModels;

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
			services.AddScoped<ILanguePisteRepository, LanguePisteRepository>();
			services.AddScoped<ICategorieRepository, CategorieRepository>();


		}
		//Views et ViewModels
		private void ConfigurePresentationServices(IServiceCollection services)
		{
			//Service de navigation
			services.AddSingleton<INavigationService, NavigationService>();

			//Views
			services.AddTransient<AbonnementAdministrateur>();
			services.AddTransient<AbonnementMembre>();
			services.AddTransient<CatalogueAdministrateur>();
			services.AddTransient<CatalogueInvite>(); //Not implemented
			services.AddTransient<CatalogueMembre>();
			services.AddTransient<FilmInfo>();
			services.AddTransient<FilmInvite>(); //Not implemented
			services.AddTransient<Inscription>();
			services.AddTransient<ModificationAbonnementAdministrateur>(); //Not implemented
			services.AddTransient<ModificationFilmAdministrateur>();
			services.AddTransient<PaiementUnitaire>(); //Not implemented
			services.AddTransient<PortefeuilleMembre>();
			services.AddTransient<ProfilMembre>();
			services.AddTransient<RechercheAvancee>();
			services.AddTransient<StatistiqueAdministrateur>();

			//ViewModels
			services.AddTransient<AccueilViewModel>();
			services.AddTransient<CatalogueAdministrateurViewModel>();
			services.AddTransient<CatalogueMembreViewModel>();
			services.AddTransient<FilmInfoViewModel>();
			services.AddTransient<InscriptionViewModel>();
			services.AddTransient<ModificationFilmAdministrateurViewModel>();

			//Page de démarrage
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
