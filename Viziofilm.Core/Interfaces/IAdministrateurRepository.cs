using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.Core.Entities;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.Core.Interfaces
{
	public interface IAdministrateurRepository : IAsyncRepository<Administrateur>, IRepository<Administrateur>
	{
		Task<IReadOnlyList<Administrateur>> GetAdministrateurBynomUsager(string nomUsager);
	}

}
