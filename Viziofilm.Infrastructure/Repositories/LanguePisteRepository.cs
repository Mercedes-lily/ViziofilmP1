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
	public class LanguePisteRepository : ILanguePisteRepository
	{
		private ViziofilmContext _viziofilmContext;

		public LanguePisteRepository(ViziofilmContext viziofilmContext)
		{
			_viziofilmContext = viziofilmContext;
		}

		public async Task<IReadOnlyList<LanguePiste>> GetAllLanguesAsync()
		{
			var list = await _viziofilmContext.LanguePiste.ToListAsync();
			return list.AsReadOnly();
		}
	}
}
