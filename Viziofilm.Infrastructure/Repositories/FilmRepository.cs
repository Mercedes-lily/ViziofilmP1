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
	public class FilmRepository : EfRepository<Film>//, IFilmRepository
	{
		public FilmRepository(ViziofilmContext viziofilmContext) : base(viziofilmContext)
		{ }

		//public Task<Film> GetByIdWithPersonnesAsync(int id)
		//{
		//	return _ViziofilmContext.Films.Include(t => t.Personnes).FirstOrDefaultAsync(t => t.Id == id);
		//}

		//public Film GetByIdWithPersonnes(int id)
		//{
		//	return _ViziofilmContext.Films.Include(t => t.Personnes).FirstOrDefault(t => t.Id == id);
		//}
	}

}
