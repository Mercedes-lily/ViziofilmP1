using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.SharedKernel;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.Core.Entities
{
	public class Categorie : BaseEntity
	{
		public string numero { get; set; }
		public string nom { get; set; }
		public virtual List<Membre> Membres { get; private set; }
		public virtual List<Film> Films { get; private set; }
		public Categorie() { }

		public Categorie(string numero, string nom)
		{
			this.numero = numero;
			this.nom = nom;
		}
		//public void AddMembre(Membre membre)
		//{
		//	Membre.Add(membre);
		//}
		//public void RemoveMembre(Personne membre)
		//{
		//	Membre.Remove(membre);
		//}

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
