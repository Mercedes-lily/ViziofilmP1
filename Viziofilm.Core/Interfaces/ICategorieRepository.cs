using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.Core.Entities;

namespace Viziofilm.Core.Interfaces
{
	public interface ICategorieRepository
	{
		Task<IReadOnlyList<Categorie>> GetAllCategoriesAsync();
	}
}
