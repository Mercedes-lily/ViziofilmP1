using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.SharedKernel;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.Core.Entities
{
	public class Cote : BaseEntity
	{
		public int cote { get; set; }
		public string nom { get; set; }
		public Cote() { }
		public Cote(int cote, string nom)
		{
			this.cote = cote;
			this.nom = nom;
		}
	}
}
