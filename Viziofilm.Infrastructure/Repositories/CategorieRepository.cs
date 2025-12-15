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
	public class CategorieRepository : ICategorieRepository
	{
		private ViziofilmContext _viziofilmContext;
		public CategorieRepository(ViziofilmContext viziofilmContext)
		{
			_viziofilmContext = viziofilmContext;
		}

		public async Task<IReadOnlyList<Categorie>> GetAllCategoriesAsync()
		{
			var list = await _viziofilmContext.Categorie.ToListAsync();
			return list.AsReadOnly();
		}
	}
}
