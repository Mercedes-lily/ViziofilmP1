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
	public class MembreRepository : EfRepository<Membre>, IMembreRepository
	{
		private ViziofilmContext _ViziofilmContext;
		public MembreRepository(ViziofilmContext viziofilmContext) : base(viziofilmContext)
		{
			this._ViziofilmContext = viziofilmContext;
		}
		public async Task<IReadOnlyList<Membre>> GetMembreBynomUsager(string nomUsager)
		{
			return await _ViziofilmContext.Membre
				.Where(a => a.nomUsager == nomUsager).ToListAsync();
		}
	}
}
