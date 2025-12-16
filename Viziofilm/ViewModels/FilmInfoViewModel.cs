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
using Viziofilm.Core;
using Viziofilm.Core.Entities;
using Viziofilm.Core.Interfaces;
using Viziofilm.Presentation.Services;

namespace Viziofilm.Presentation.ViewModels
{
    public class FilmInfoViewModel : INotifyPropertyChanged
	{
		private readonly IViziofilmService _viziofilmService;
		private readonly INavigationService _navigationService;
		private Film _filmSelectionne;
		private string _titre;
		private int _anneeSortie;
		private int _duree;
		private decimal _prix;
		private string _synopsis;
		private string _motsCles;
		private StatutDisponible _statutSelectionne;
		private Categorie _categorieSelectionnee;
		private LanguePiste _languePisteSelectionnee;

		public StatutDisponible StatutSelectionne
		{
			get => _statutSelectionne;
			set { _statutSelectionne = value; OnPropertyChanged(); }
		}

		public string Titre
		{
			get => _titre;
			set { _titre = value; OnPropertyChanged(); }
		}
		public int AnneeSortie
		{
			get => _anneeSortie;
			set { _anneeSortie = value; OnPropertyChanged(); }
		}
		public int Duree
		{
			get => _duree;
			set { _duree = value; OnPropertyChanged(); }
		}
		public decimal Prix
		{
			get => _prix;
			set { _prix = value; OnPropertyChanged(); }
		}
		public string Synopsis
		{
			get => _synopsis;
			set { _synopsis = value; OnPropertyChanged(); }
		}
		public string MotsCles
		{
			get => _motsCles;
			set { _motsCles = value; OnPropertyChanged(); }
		}
		public Categorie CategorieSelectionnee
		{
			get => _categorieSelectionnee;
			set { _categorieSelectionnee = value; OnPropertyChanged(); }
		}
		public LanguePiste LanguePisteSelectionnee
		{
			get => _languePisteSelectionnee;
			set { _languePisteSelectionnee = value; OnPropertyChanged(); }
		}
		public Film FilmSelectionne
		{
			get => _filmSelectionne;
			set { _filmSelectionne = value; OnPropertyChanged(); }
		}
		public ICommand BoutonGererAbonnementCommande { get; private set; }
		public ICommand BoutonProfilCommande { get; private set; }
		public ICommand BoutonPortefeuilleCommande { get; private set; }
		public ICommand BoutonCatalogueFilmCommande { get; private set; }
		public ICommand BoutonVisionnerFilmCommande { get; private set; }

		public Action FermerFenetre { get; set; }
		public FilmInfoViewModel(IViziofilmService viziofilmService, INavigationService navigationService)
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
			BoutonPortefeuilleCommande = new RelayCommand(
				o => true,
				o => Portefeuille()
				);
			BoutonCatalogueFilmCommande = new RelayCommand(
				o => true,
				o => ToCatalogueMembre()
				);
			BoutonVisionnerFilmCommande = new RelayCommand(
				o => true,
				o => Visionner()
				);
		}
		private void Portefeuille()
		{
			_navigationService.NavigateToPortefeuilleMembre();
			FermerFenetre?.Invoke();
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
		private void Visionner()
		{
			MessageBox.Show("Bon visionnement!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
			_navigationService.NavigateToCatalogueMembre();
			FermerFenetre?.Invoke();
		}
		private void ToCatalogueMembre()
		{
			_navigationService.NavigateToCatalogueMembre();
			FermerFenetre?.Invoke();
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public async Task ChargerFilm(int filmId)
		{
			var film = await _viziofilmService.GetFilmByIdAsync(filmId);
			FilmSelectionne = film;
			InitFilm(film);
		}
		public void InitFilm(Film film)
		{
			Titre = film.Titre;
			AnneeSortie = film.AnneeSortie;
			Duree = film.Duree;
			Prix = film.Prix;
			Synopsis = film.Synopsis;
			StatutSelectionne = film.Statut;
			MotsCles = film.MotsCles;
			CategorieSelectionnee = film.Categories.First(); //Utiliser le premier, manque de temps pour CheckBox et many-to-many...
			LanguePisteSelectionnee = film.LanguePistes.First(); //Utiliser le premier, manque de temps pour CheckBox et many-to-many...

		}
	}
}
