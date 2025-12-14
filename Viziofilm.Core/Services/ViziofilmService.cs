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
		private readonly IAdministrateurRepository _administrateurRepository;
		private readonly IMembreRepository _membreRepository;


		public ViziofilmService(IFilmRepository filmRepository, 
			IAdministrateurRepository administrateurRepository,
			IMembreRepository membreRepository)
		{
			_filmRepository = filmRepository;
			_administrateurRepository = administrateurRepository;
			_membreRepository = membreRepository;
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

		public async Task<IReadOnlyList<Administrateur>> GetAdministrateurBynomUsager(string nomUsager)
		{
			return await _administrateurRepository.GetAdministrateurBynomUsager(nomUsager);
		}
		public async Task<IReadOnlyList<Membre>> GetMembreBynomUsager(string nomUsager)
		{
			return await _membreRepository.GetMembreBynomUsager(nomUsager);
		}

		public async Task UpdateFilm(Film film)
		{
			await _filmRepository.UpdateAsync(film);
		}
		public async Task<Film> GetFilmById(int id)
		{
			return await _filmRepository.GetByIdAsync(id);
		}	


	}
}
