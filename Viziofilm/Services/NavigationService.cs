using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Viziofilm.Presentation.ViewModels;

namespace Viziofilm.Presentation.Services
{
	public class NavigationService : INavigationService
	{
		public readonly IServiceProvider _serviceProvider;

		public NavigationService(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void NavigateToCatalogueAdministrateur()
		{
			var catalogueAdministrateurFenetre = _serviceProvider.GetRequiredService<CatalogueAdministrateur>();
			catalogueAdministrateurFenetre.Show();
		}

		public void NavigateToCatalogueMembre()
		{
			var catalogueMembreFenetre = _serviceProvider.GetRequiredService<CatalogueMembre>();
			catalogueMembreFenetre.Show();
		}

		public void NavigateToInscription()
		{
			var inscriptionFenetre = _serviceProvider.GetRequiredService<Inscription>();
			inscriptionFenetre.Show();
		}
		public void NavigateToAccueil()
		{
			var accueilFenetre = _serviceProvider.GetRequiredService<Accueil>();
			accueilFenetre.Show();
		}

		public void NavigateToStatistiqueAdministrateur()
		{
			var statFenetre = _serviceProvider.GetRequiredService<StatistiqueAdministrateur>();
			statFenetre.Show();
		}

		public void NavigateToAbonnementAdministrateur()
		{
			var abonnementAdminFenetre = _serviceProvider.GetRequiredService<AbonnementAdministrateur>();
			abonnementAdminFenetre.Show();
		}

		public void NavigateToModificationFilmAdministrateur(int FilmId)
		{
			var modificationFilmFenetre = _serviceProvider.GetRequiredService<ModificationFilmAdministrateur>();
			if (modificationFilmFenetre.DataContext is ModificationFilmAdministrateurViewModel viewModel)
			{
				viewModel.ChargerFilm(FilmId);
			}
			modificationFilmFenetre.Show();
		}
	}
}
