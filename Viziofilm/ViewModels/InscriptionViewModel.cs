using GestionFleur.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Viziofilm.Core.Interfaces;
using Viziofilm.Core.Entities;
using Viziofilm.Presentation.Services;
using System.Windows.Controls;

namespace Viziofilm.Presentation.ViewModels
{
	public class InscriptionViewModel : INotifyPropertyChanged
	{
		private readonly IViziofilmService _viziofilmService;
		private readonly INavigationService _navigationService;
		public List<string> TousLesPaysDisponibles { get; } = new List<string>
		{
			"Canada", "Etats-Unis", "France", "Australie", "La Reunion", "Perou"
		};

		private string _nomUtilisateur;
		public string NomUtilisateur
		{
			get => _nomUtilisateur;
			set { _nomUtilisateur = value; OnPropertyChanged(); }
		}

		private string _motDePasse;
		public string MotDePasse
		{
			get => _motDePasse;
			set { _motDePasse = value; OnPropertyChanged(); }
		}
		public ICommand BoutonSoumettreCommande { get; private set; }
		public ICommand BoutonRetourCommande { get; private set; }

		private string _messageErreur;
		public string MessageErreur
		{
			get => _messageErreur;
			set { _messageErreur = value; OnPropertyChanged(); }
		}
		public string _nom;
		public string Nom
		{
			get => _nom;
			set { _nom = value; OnPropertyChanged(); }
		}
		public string _prenom;
		public string Prenom
		{
			get => _prenom;
			set { _prenom = value; OnPropertyChanged(); }
		}
		public string _adresse;
		public string Adresse
		{
			get => _adresse;
			set { _adresse = value; OnPropertyChanged(); }
		}
		public string _ville;
		public string Ville
		{
			get => _ville;
			set { _ville = value; OnPropertyChanged(); }
		}
		public string _codePostal;
		public string CodePostal
		{
			get => _codePostal;
			set { _codePostal = value; OnPropertyChanged(); }
		}
		public string _pays;
		public string Pays
		{
			get => _pays;
			set { _pays = value; OnPropertyChanged(); }
		}
		public string _adresseCourriel;
		public string AdresseCourriel
		{
			get => _adresseCourriel;
			set { _adresseCourriel = value; OnPropertyChanged(); }
		}
		public Action FermerFenetre { get; set; }


		public InscriptionViewModel(IViziofilmService viziofilmService, INavigationService navigationService)
		{
			_viziofilmService = viziofilmService;
			_navigationService = navigationService;
			BoutonSoumettreCommande = new RelayCommand(
					o => true,
					o => BoutonSoumettre()
				);
			BoutonRetourCommande = new RelayCommand(
					o => true,
					o => BoutonRetour()
					);

		}

		private async void BoutonSoumettre()
		{
			if (NomUtilisateur == null ||
				MotDePasse == null ||
				Nom == null ||
				Prenom == null ||
				Adresse == null ||
				Ville == null ||
				CodePostal == null ||
				Pays == null ||
				AdresseCourriel == null)
			{
				MessageErreur = "Veuillez remplir tous les champs.";
				return;
			}
			Membre nouveauMembre = new Membre
			{
				nomUsager = NomUtilisateur,
				motDePasse = MotDePasse,
				nom = Nom,
				prenom = Prenom,
				addresse = Adresse,
				addresseCourriel = AdresseCourriel,
				ville = Ville,
				codePostal = CodePostal,
				pays = Pays,};
			try
			{
				await _viziofilmService.AddMembreAsync(nouveauMembre);
				MessageBox.Show("Inscription réussie!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
				_navigationService.NavigateToAccueil();
				FermerFenetre?.Invoke();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Erreur d'inscription : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
				MessageErreur = $"Erreur : {ex.Message}";
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		

		public void BoutonRetour()
		{
			_navigationService.NavigateToAccueil();
			FermerFenetre?.Invoke();


		}
	}
}
