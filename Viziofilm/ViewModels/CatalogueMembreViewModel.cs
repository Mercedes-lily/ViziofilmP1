using GestionFleur.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Viziofilm.Core.Entities;
using Viziofilm.Core.Interfaces;
using Viziofilm.Presentation.Services;

namespace Viziofilm.Presentation.ViewModels
{
	public class CatalogueMembreViewModel : INotifyPropertyChanged
	{
		private readonly IViziofilmService _viziofilmService;
		private readonly INavigationService _navigationService;
		private string _recherche;
		public string Recherche
		{
			get => _recherche;
			set { _recherche = value; OnPropertyChanged(); }
		}
		private ObservableCollection<Film> _filmTrouve;
		public ObservableCollection<Film> FilmTrouve
		{
			get => _filmTrouve;
			set { _filmTrouve = value; OnPropertyChanged(); }
		}
		public ICommand BoutonGererAbonnementCommande { get; private set; }
		public ICommand BoutonProfilCommande { get; private set; }
		public ICommand BoutonDeconnexionCommande { get; private set; }
		public ICommand BoutonRechercherFilmCommande { get; private set; }
		public ICommand BoutonRechercheAvanceeCommande { get; private set; }
		public ICommand BoutonPortefeuilleCommande { get; private set; }
		public ICommand BoutonInfoFilmCommande { get; private set; }
		public Action FermerFenetre { get; set; }
		public CatalogueMembreViewModel(IViziofilmService viziofilmService, INavigationService navigationService)
		{
			_viziofilmService = viziofilmService;
			_navigationService = navigationService;
			BoutonGererAbonnementCommande = new RelayCommand(
					o => true,
					o => GererAbonnement()
				);
			BoutonProfilCommande = new RelayCommand(
					o => true,
					o => GererProfil()
				);
			BoutonDeconnexionCommande = new RelayCommand(
					o => true,
					o => Deconnexion()
				);
			BoutonRechercherFilmCommande = new RelayCommand(
					o => true,
					o => RechercherFilm()
				);
			BoutonRechercheAvanceeCommande = new RelayCommand(
					o => true,
					o => RechercheAvance()
				);
			BoutonPortefeuilleCommande = new RelayCommand(
				o => true,
				o => Portefeuille()
				);
			BoutonInfoFilmCommande = new RelayCommand(
				o => true,
				o => AfficherInfo(o)
				);
		}

		private void AfficherInfo(Object film)
		{
			Film filmToShow = (Film)film;
			if (filmToShow == null) 
				return;
			_navigationService.NavigateToFilmInfo(filmToShow.Id);
		}

		private void GererAbonnement()
		{
			_navigationService.NavigateToAbonnementMembre();
			FermerFenetre?.Invoke();
		}
		private void GererProfil()
		{
			_navigationService.NavigateToProfilMembre();
			FermerFenetre?.Invoke();
		}
		private void Deconnexion()
		{
			_navigationService.NavigateToAccueil();
			FermerFenetre?.Invoke();
		}
		private async void RechercherFilm()
		{
			if (string.IsNullOrEmpty(Recherche))
			{
				MessageBox.Show("Veuillez entrer un terme de recherche.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}
			try
			{
				var resultats = await _viziofilmService.GetFilmByMotCleAsync(Recherche);
				FilmTrouve = new ObservableCollection<Film>(resultats);
				if (resultats.Count == 0)
					MessageBox.Show("Aucun résultat trouvé.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Erreur lors de la recherche : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void RechercheAvance()
		{
			_navigationService.NavigateToRechercheAvancee();
			FermerFenetre?.Invoke();
		}
		private void Portefeuille()
		{
			_navigationService.NavigateToPortefeuilleMembre();
			FermerFenetre?.Invoke();
		}
		
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}