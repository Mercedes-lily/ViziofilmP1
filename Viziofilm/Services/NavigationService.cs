using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Viziofilm.Presentation.Services
{
	public class NavigationService : INavigationService
	{
		public readonly IServiceProvider _serviceProvider;

		public NavigationService(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void FermerFenetre()
		{
			Application.Current.Windows
				.OfType<Window>()
				.FirstOrDefault(w => w.IsActive)?
				.Close();
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
			var InscriptionFenetre = _serviceProvider.GetRequiredService<Inscription>();
			InscriptionFenetre.Show();
		}
		
	}
}
