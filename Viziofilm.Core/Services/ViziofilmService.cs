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
		private readonly IAsyncRepository<Administrateur> _administrateurRepository;

		public ViziofilmService(IFilmRepository filmRepository, IAsyncRepository<Administrateur> administrateurRepository)
		{
			_filmRepository = filmRepository;
			_administrateurRepository = administrateurRepository;
		}

		public async Task AddFilm(Film film)
		{
			await _filmRepository.AddAsync(film);
		}

		public async Task DeleteFilm(Film film)
		{
			await _filmRepository.DeleteAsync(film);
		}

		public async Task<IReadOnlyList<Film>> GetAllFilms()
		{
			return await _filmRepository.ListAllAsync();
		}

		public async Task<Film> GetFilmById(int id)
		{
			return await _filmRepository.GetByIdAsync(id);
		}

		public async Task<IReadOnlyList<Administrateur>> GetAllAdministrateurs()
		{
			return await _administrateurRepository.ListAllAsync();
		}

		public async Task<Administrateur> GetAdministrateur(int Id)
		{
			return await _administrateurRepository.GetByIdAsync(Id);
		}

		public async Task UpdateFilm(Film film)
		{
			await _filmRepository.UpdateAsync(film);
		}


	}
}
