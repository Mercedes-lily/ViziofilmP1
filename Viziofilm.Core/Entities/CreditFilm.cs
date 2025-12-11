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
		public TypeRole role { get; set; }
		public CreditFilm() { }

		public CreditFilm(TypeRole role) 
		{ 
			this.role = role;
		}
	}
}
