using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.Core.Entities;

namespace Viziofilm.Core.Interfaces
{
	public interface IViziofilmService
	{
		Task AddFilmAsync(Film film);
		Task UpdateFilmAsync(Film film);
		Task DeleteFilmAsync(Film film);
		Task<Film> GetFilmByIdAsync(int id);
		Task<IReadOnlyList<Film>> GetAllFilmsAsync();
		Task<IReadOnlyList<Administrateur>> GetAdministrateurBynomUsagerAsync(string nomUsager);
		Task<IReadOnlyList<Membre>> GetMembreBynomUsagerAsync(string nomUsager);
		Task AddMembreAsync(Membre membre);
		Task<IReadOnlyList<LanguePiste>> GetAllLanguesAsync();
		Task<IReadOnlyList<Categorie>> GetAllCategoriesAsync();
		Task<IReadOnlyList<Film>> GetFilmByMotCleAsync(string terme);
	}
}
