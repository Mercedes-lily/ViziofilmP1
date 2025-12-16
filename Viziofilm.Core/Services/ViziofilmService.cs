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
		private readonly ILanguePisteRepository _languePisteRepository;
		private readonly ICategorieRepository _categorieRepository;


		public ViziofilmService(IFilmRepository filmRepository, 
			IAdministrateurRepository administrateurRepository,
			IMembreRepository membreRepository, 
			ILanguePisteRepository languePisteRepository,
			ICategorieRepository categorieRepository)
		{
			_filmRepository = filmRepository;
			_administrateurRepository = administrateurRepository;
			_membreRepository = membreRepository;
			_languePisteRepository = languePisteRepository;
			_categorieRepository = categorieRepository;
		}

		public async Task AddFilmAsync(Film film)
		{
			await _filmRepository.AddAsync(film);
		}

		public async Task AddMembreAsync(Membre membre)
		{
			await _membreRepository.AddAsync(membre);
		}



		public async Task DeleteFilmAsync(Film film)
		{
			await _filmRepository.DeleteAsync(film);
		}

		public async Task<IReadOnlyList<Film>> GetAllFilmsAsync()
		{
			return await _filmRepository.ListAllAsync();
		}

		public async Task<IReadOnlyList<Administrateur>> GetAdministrateurBynomUsagerAsync(string nomUsager)
		{
			return await _administrateurRepository.GetAdministrateurBynomUsager(nomUsager);
		}
		public async Task<IReadOnlyList<Membre>> GetMembreBynomUsagerAsync(string nomUsager)
		{
			return await _membreRepository.GetMembreBynomUsager(nomUsager);
		}

		public async Task UpdateFilmAsync(Film film)
		{
			await _filmRepository.UpdateAsync(film);
		}
		public async Task<Film> GetFilmByIdAsync(int id)
		{
			return await _filmRepository.GetByIdAsync(id);
		}

		public async Task<IReadOnlyList<LanguePiste>> GetAllLanguesAsync()
		{
			return await _languePisteRepository.GetAllLanguesAsync();
		}

		public async Task<IReadOnlyList<Categorie>> GetAllCategoriesAsync()
		{
			return await _categorieRepository.GetAllCategoriesAsync();
		}

		public async Task<IReadOnlyList<Film>> GetFilmByMotCleAsync(string terme)
		{
			return await _filmRepository.GetFilmByMotCleAsync(terme);
		}
	}
}
