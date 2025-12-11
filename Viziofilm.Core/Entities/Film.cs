using Viziofilm.SharedKernel;
using Viziofilm.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Viziofilm.Core.Entities
{
	public class Film : BaseEntity, IAggregateRoot
	{
		public string Number { get; set; }
		public string Titre { get; set; }
		public int AnneeSortie { get; set; }
		public int Duree { get; set; }
		public decimal Prix { get; set; }
		public string Synopsis { get; set; }
		public StatutDisponible Statut { get; set; }
		public string MotsCles { get; set; }
		public virtual List<Personne> Personnes { get; private set; } = new List<Personne>();
		public virtual List<Categorie> Categories { get; private set; }
		public virtual List<LanguePiste> LanguePistes { get; private set; }
		public Film()
		{

		}

		public Film(string number, string titre, int anneeSortie, int duree, decimal prix, string synopsis, StatutDisponible statut, string motsCles)
		{
			this.Number = number;
			this.Titre = titre;
			this.AnneeSortie = anneeSortie;
			this.Duree = duree;
			this.Prix = prix;
			this.Synopsis = synopsis;
			this.Statut = statut;
			this.MotsCles = motsCles;
		}

		public void AddPersonne(Personne personne)
		{
			Personnes.Add(personne);
		}
		public void RemovePersonne(Personne personne)
		{
			Personnes.Remove(personne);
		}
		//public void AddCategorie(Categorie categorie)
		//{
		//	Categorie.Add(categorie);
		//}
		//public void RemoveCategorie(Categorie categorie)
		//{
		//	Categorie.Remove(categorie);
		//}
		//public void AddLanguePiste(LanguePiste languePiste)
		//{
		//	LanguePiste.Add(personne);
		//}
		//public void RemoveLanguePiste(LanguePiste languePiste)
		//{
		//	LanguePiste.Remove(languePiste);
		//}

	}
}
