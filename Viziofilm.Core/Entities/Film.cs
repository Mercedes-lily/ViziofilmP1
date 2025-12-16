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
		public string Titre { get; set; }
		public int AnneeSortie { get; set; }
		public int Duree { get; set; }
		public decimal Prix { get; set; }
		public string Synopsis { get; set; }
		public StatutDisponible Statut { get; set; }
		public string MotsCles { get; set; }
		public ICollection<Cote> Cotes { get; set; }
		public ICollection<CreditFilm> Credit { get; set; }
		public virtual List<Categorie> Categories { get; private set; }
		public virtual List<LanguePiste> LanguePistes { get; private set; }
		public Film()
		{

		}

		public Film(string titre, int anneeSortie, int duree, decimal prix, string synopsis, StatutDisponible statut, string motsCles)
		{
			this.Titre = titre;
			this.AnneeSortie = anneeSortie;
			this.Duree = duree;
			this.Prix = prix;
			this.Synopsis = synopsis;
			this.Statut = statut;
			this.MotsCles = motsCles;
		}
	}
}
