using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.SharedKernel;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.Core.Entities
{
	public class LanguePiste : BaseEntity
	{

		public string code { get; set; }
		public TypePiste type { get; set; }
		public virtual List<Film> Films { get; private set; }
		public LanguePiste() { }

		public LanguePiste(string code, TypePiste type)
		{
			this.code = code;
			this.type = type;
		}
		//public void AddFilm(Film film)
		//{
		//	Film.Add(film);
		//}
		//public void RemoveFilm(Film film)
		//{
		//	Film.Remove(film);
		//}
	}
}
