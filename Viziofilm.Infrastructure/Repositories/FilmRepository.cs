using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.Core.Entities;
using Viziofilm.Core.Interfaces;

namespace Viziofilm.Infrastructure.Repositories
{
	public class FilmRepository : EfRepository<Film>, IFilmRepository
	{
		public FilmRepository(ViziofilmContext viziofilmContext) : base(viziofilmContext)
		{ }

		public async Task<Film> GetByIdWithDetailsAsync(int id)
		{
			return await _ViziofilmContext.Films
				.Include(f => f.Cotes)
				.Include(f => f.AnneeSortie)
				.Include(f => f.Duree)
				.Include(f => f.Categories)
				.Include(f => f.LanguePistes)
				.Include(f => f.Synopsis)
				.Include(f => f.Cotes)
				.Include(f => f.Credit)
				.ThenInclude(cf => cf.personne)
				.Include(f => f.Credit)
				.ThenInclude(cf => cf.role)
				.FirstOrDefaultAsync(f => f.Id == id);
		}

		public async Task<IReadOnlyList<Film>> GetFilmByMotCleAsync(string motCle)
		{
			string patternMotCle = motCle.ToLower();
			return await _ViziofilmContext.Films
				.Where(f => f.Titre.ToLower().Contains(patternMotCle) ||
				f.MotsCles.ToLower().Contains(patternMotCle) ||
				f.Synopsis.ToLower().Contains(patternMotCle)).ToListAsync();
		}
	}

}
