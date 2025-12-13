using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.SharedKernel;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.Core.Entities
{
	public class AbonnementPlan : BaseEntity, IAggregateRoot
	{
		public string numero { get; set; }
		public string nom { get; set; }
		public float prixMensuel { get; set; }
		public int limiteAppareils { get; set; }

		public AbonnementPlan() { }


		public AbonnementPlan(string numero, string nom, float prixMensuel, int limiteAppareils)
		{
			this.numero = numero;
			this.nom = nom;
			this.prixMensuel = prixMensuel;
			this.limiteAppareils = limiteAppareils;
		}
	}
}
