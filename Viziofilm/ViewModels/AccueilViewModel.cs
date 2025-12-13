using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.Core.Interfaces;
using System.Collections.ObjectModel;

namespace Viziofilm.Presentation.ViewModels
{
	public class AccueilViewModel
	{
		private readonly IViziofilmService _viziofilmService;
		public AccueilViewModel(IViziofilmService viziofilmService)
		{
			_viziofilmService = viziofilmService;
			LoadData(); // Charger les données au démarrage
		}
		private async void LoadData()
		{
			// Appeler un Use Case du Core
			var films = await _viziofilmService.GetAllFilms();

			// Mapper les Entities du Core en ViewModels/DTOs pour la vue WPF
			// ... Logique de mapping ...
			// Films.Clear();
			// foreach (var film in films)
			// {
			//     Films.Add(new FilmViewModel(film));
			// }
		}
	}
}
