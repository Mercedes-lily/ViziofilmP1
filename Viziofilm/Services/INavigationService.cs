using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

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
		void NavigateToAbonnementMembre();
		void NavigateToProfilMembre();
		void NavigateToFilmInfo(int FilmId);
		void NavigateToRechercheAvancee();
		void NavigateToPortefeuilleMembre();
	}
}
