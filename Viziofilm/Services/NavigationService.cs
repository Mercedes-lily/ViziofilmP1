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

		public void NavigateToAbonnementMembre()
		{
			var abonnementMembreFenetre = _serviceProvider.GetRequiredService<AbonnementMembre>();
			abonnementMembreFenetre.Show();
		}

		public void NavigateToProfilMembre()
		{
			var profilMembreFenetre = _serviceProvider.GetRequiredService<ProfilMembre>();
			profilMembreFenetre.Show();
		}

		public void NavigateToFilmInfo(int FilmId)
		{
			var filmInfoFenetre = _serviceProvider.GetRequiredService<FilmInfo>();
			if (filmInfoFenetre.DataContext is FilmInfoViewModel viewModel)
			{
				viewModel.ChargerFilm(FilmId);
			}
			filmInfoFenetre.Show();
		}

		public void NavigateToRechercheAvancee()
		{
			var rechercheAvanceeFenetre = _serviceProvider.GetRequiredService<RechercheAvancee>();
			rechercheAvanceeFenetre.Show();
		}

		public void NavigateToPortefeuilleMembre()
		{
			var portefeuilleMembreFenetre = _serviceProvider.GetRequiredService<PortefeuilleMembre>();
			portefeuilleMembreFenetre.Show();
		}
	}
}
