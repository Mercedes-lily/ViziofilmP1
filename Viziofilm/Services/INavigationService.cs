using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viziofilm.Presentation.Services
{
	public interface INavigationService
	{
		void NavigateToCatalogueAdministrateur();
		void NavigateToCatalogueMembre();
		void NavigateToInscription();
		void NavigateToAccueil();
		void NavigateToStatistiqueAdministrateur();
		void NavigateToAbonnementAdministrateur();
		void NavigateToModificationFilmAdministrateur(int FilmId);
	}
}
