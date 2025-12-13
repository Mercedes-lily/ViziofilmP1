using Viziofilm.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.Core.Entities;

namespace Viziofilm.Core.Interfaces
{
	public interface IFilmRepository : IAsyncRepository<Film>, IRepository<Film>
	{
		Task<Film> GetByIdWithDetailsAsync(int id);
		Task<IReadOnlyList<Film>> RechercherFilm(string motCle);
	}

}
