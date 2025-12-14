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
	public class AdministrateurRepository : EfRepository<Administrateur>, IAdministrateurRepository
	{
		private ViziofilmContext _ViziofilmContext;
		public AdministrateurRepository(ViziofilmContext viziofilmContext) : base(viziofilmContext)
		{ 
			this._ViziofilmContext = viziofilmContext;
		}
		public async Task<IReadOnlyList<Administrateur>> GetAdministrateurBynomUsager(string nomUsager)
		{
			return await _ViziofilmContext.Administrateur
				.Where(a => a.nomUsager == nomUsager).ToListAsync();
		}
	}
}
