using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.Core.Entities;

namespace Viziofilm.Core.Specifications
{
	public class FilmByNumber : BaseSpecification<Film>
	{
		public FilmByNumber(string number) : base(film => film.Number == number)
		{ }
	}

}
