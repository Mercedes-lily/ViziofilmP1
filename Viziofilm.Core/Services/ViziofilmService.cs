using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.Core.Entities;
using Viziofilm.Core.Interfaces;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.Core.Services
{
	public class ViziofilmService : IViziofilmService
	{
		private readonly IFilmRepository _filmRepository;
		private readonly IAsyncRepository<Personne> _personneRepository;

		public ViziofilmService(IFilmRepository filmRepository, IAsyncRepository<Personne> personneRepository)
		{
			_filmRepository = filmRepository;
			_personneRepository = personneRepository;
		}

		public async Task AddFilm(Film film)
		{
			await _filmRepository.AddAsync(film);
		}

		public async Task DeleteFilm(Film film)
		{
			await _filmRepository.DeleteAsync(film);
		}

		public async Task DeletePersonne(Personne personne)
		{
			await _personneRepository.DeleteAsync(personne);
		}

		public async Task<IReadOnlyList<Film>> GetAllFilms()
		{
			return await _filmRepository.ListAllAsync();
		}

		public async Task<Film> GetFilmById(int id)
		{
			return await _filmRepository.GetByIdAsync(id);
		}

		public async Task<Personne> GetPersonne(int Id)
		{
			return await _personneRepository.GetByIdAsync(Id);
		}

		public async Task UpdateFilm(Film film)
		{
			await _filmRepository.UpdateAsync(film);
		}

		public async Task UpdatePersonne(Personne personne)
		{
			await _personneRepository.UpdateAsync(personne);
		}
	}
}
