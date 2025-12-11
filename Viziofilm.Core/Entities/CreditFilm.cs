using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.SharedKernel;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.Core.Entities
{
	public class CreditFilm : BaseEntity
	{

		public int PersonneId { get; set; }
		public Personne personne { get; set; }

		public int FilmId { get; set; }
		public Film film { get; set; }

		public TypeRole role { get; set; }
		public CreditFilm() { }

		public CreditFilm(TypeRole role) 
		{ 
			this.role = role;
		}
	}
}
