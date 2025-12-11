using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.SharedKernel;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.Core.Entities
{
	public class Administrateur : Utilisateur
	{
			public string numero { get; set; }
			public string nomUsager { get; set; }
			public string motDePasse { get; set; }

			public Administrateur()
			{
			}

			public Administrateur(string numero, string nomUsager, string motDePasse)
			{
				this.numero = numero;
				this.nomUsager = nomUsager;
				this.motDePasse = motDePasse;
			}
		}
}
