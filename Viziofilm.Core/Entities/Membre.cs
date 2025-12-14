using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viziofilm.SharedKernel;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.Core.Entities
{
	public class Membre : Utilisateur
	{
		public string numero { get; set; }
		public string nomUsager { get; set; }
		public string motDePasse { get; set; }
		public string nom { get; set; }
		public string prenom { get; set; }
		public string addresse { get; set; }
		public string ville { get; set; }
		public string addresseCourriel { get; set; }
		public string codePostal { get; set; }
		public string pays { get; set; }
		public virtual List<Categorie> CategoriePreferees { get; private set; }


		public Membre()
		{
		}

		public Membre(string numero, string nomUsager, string motDePasse, string nom, string prenom, string addresse, string ville, string addresseCourriel, string pays, string codePostal)
		{
			this.numero = numero;
			this.nomUsager = nomUsager;
			this.motDePasse = motDePasse;
			this.nom = nom;
			this.prenom = prenom;
			this.addresse = addresse;
			this.ville = ville;
			this.addresseCourriel = addresseCourriel;
			this.pays = pays;
			this.codePostal = codePostal;
		}
		//public void AddCategorie(Categorie categorie)
		//{
		//	Categorie.Add(categorie);
		//}
		//public void RemoveCategorie(Categorie categorie)
		//{
		//	Categorie.Remove(categorie);
		//}
	}
}
