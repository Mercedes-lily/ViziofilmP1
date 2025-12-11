using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.SharedKernel;

namespace Viziofilm.Core.Entities
{
	public class Session : BaseEntity
	{
		public string numero { get; set; }
		public DateTime dateConnexion { get; set; }
		public DateTime dateDeconnexion { get; set; }

		public Utilisateur UsagerAuthentifie;
		public Session() { }
		public Session(string numero, DateTime dateConnexion, DateTime dateDeconnexion)
		{
			this.numero = numero;
			this.dateConnexion = dateConnexion;
			this.dateDeconnexion = dateDeconnexion;
		}

	}
}
