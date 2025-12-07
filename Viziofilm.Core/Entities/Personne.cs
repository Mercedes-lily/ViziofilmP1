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
	public class Personne : BaseEntity, IAggregateRoot
	{
		public string numero { get; set; }
		public string nom { get; set; }
		public string pays { get; set; }
		public TypePersonne typePersonne { get; set; }
		public virtual List<Film> Films { get; private set; } = new List<Film>();

		public Personne()
		{
		}

		public Personne(string numero, string nom, string pays, TypePersonne typePersonne)
		{
			this.numero = numero;
			this.nom = nom;
			this.pays = pays;
			this.typePersonne = typePersonne;
		}

		public void AddFilm(Film film)
		{
			Films.Add(film);
		}
		public void RemoveFilm(Film film)
		{
			Films.Remove(film);
		}
	}
}
