using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.Core.Entities;

namespace Viziofilm.Core.Interfaces
{
	public interface ILanguePisteRepository
	{
		Task<IReadOnlyList<LanguePiste>> GetAllLanguesAsync();
	}
}
