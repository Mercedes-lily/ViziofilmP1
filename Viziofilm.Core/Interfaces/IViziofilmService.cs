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
		Task AddFilm(Film film);
		Task UpdateFilm(Film film);
		Task DeleteFilm(Film film);
		Task<Film> GetFilmById(int id);
		Task<IReadOnlyList<Film>> GetAllFilms();
		Task<Personne> GetPersonne(int Id);
		Task DeletePersonne(Personne personne);
		Task UpdatePersonne(Personne personne);
	}
}
