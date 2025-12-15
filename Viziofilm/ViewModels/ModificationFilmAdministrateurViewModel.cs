using GestionFleur.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Viziofilm.Core;
using Viziofilm.Core.Entities;
using Viziofilm.Core.Interfaces;
using Viziofilm.Presentation.Services;

namespace Viziofilm.Presentation.ViewModels
{
	public class ModificationFilmAdministrateurViewModel : INotifyPropertyChanged
	{
		private readonly IViziofilmService _viziofilmService;
		private readonly INavigationService _navigationService;
		private string _messageErreur;
		private string _titre;
		private int _anneeSortie;
		private int _duree;
		private decimal _prix;
		private string _synopsis;
		private StatutDisponible _statut;
		private string _motsCles;
		private ObservableCollection<Categorie> _toutesLesCategories;
		private ObservableCollection<LanguePiste> _toutesLesLangues;
		private Categorie _categorieSelectionnee;
		private LanguePiste _languePisteSelectionnee;
		private Film _filmSelectionne;
		private StatutDisponible _statutSelectionne;
		public IEnumerable<StatutDisponible> StatutsDisponibles { get; } = Enum.GetValues(typeof(StatutDisponible)).Cast<StatutDisponible>();
		public ObservableCollection<Categorie> ToutesLesCategories
		{
			get => _toutesLesCategories;
			set { _toutesLesCategories = value; OnPropertyChanged(); }
		}
		public IEnumerable<StatutDisponible> TousLesStatuts
		{
			get
			{
				return Enum.GetValues(typeof(StatutDisponible)).Cast<StatutDisponible>();
			}
		}
		public StatutDisponible StatutSelectionne
		{
			get => _statutSelectionne;
			set { _statutSelectionne = value; OnPropertyChanged(); }
		}
		public ObservableCollection<LanguePiste> ToutesLesLangues
		{
			get => _toutesLesLangues;
			set { _toutesLesLangues = value; OnPropertyChanged(); }
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
		public StatutDisponible Statut
		{
			get => _statut;
			set { _statut = value; OnPropertyChanged(); }
		}
		public string MotsCles
		{
			get => _motsCles;
			set { _motsCles = value; OnPropertyChanged(); }
		}
		public string MessageErreur
		{
			get => _messageErreur;
			set { _messageErreur = value; OnPropertyChanged(); }
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
		public ICommand BoutonEnregistrerFilmCommande { get; private set; }
		public ICommand BoutonAnnulerFilmCommande { get; private set; }
		public Action FermerFenetre { get; set; }
		public ModificationFilmAdministrateurViewModel(IViziofilmService visiofilmService, INavigationService navigationService)
		{
			Task.Run(async () => await LoadAvailableData());
			_viziofilmService = visiofilmService;
			_navigationService = navigationService;
			BoutonEnregistrerFilmCommande = new RelayCommand(
					o => true,
					o => BoutonEnregirstrerFilm()
				);
			BoutonAnnulerFilmCommande = new RelayCommand(
					o => true,
					o => BoutonAnnulerFilm()
				);
		}

		private void BoutonAnnulerFilm()
		{
			_navigationService.NavigateToCatalogueAdministrateur();
			FermerFenetre?.Invoke();
		}

		private void BoutonEnregirstrerFilm()
		{
			///////THINGS TO SAVE AS A NEW FILM OR MODIFICATION
			FermerFenetre?.Invoke();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public async Task ChargerFilm(int filmId)
		{
			if (filmId != -1)
			{
				var film = await _viziofilmService.GetFilmByIdAsync(filmId);
				InitFilm(film);
			}
		}
		public void InitFilm(Film film)
		{
			Titre = film.Titre;
			AnneeSortie = film.AnneeSortie;
			Duree = film.Duree;
			Prix = film.Prix;
			Synopsis = film.Synopsis;
			Statut = film.Statut;
			MotsCles = film.MotsCles;
			CategorieSelectionnee = film.Categories.First(); //Utiliser le premier, manque de temps pour CheckBox...
			LanguePisteSelectionnee = film.LanguePistes.First(); //Utiliser le premier, manque de temps pour CheckBox...

		}
		public async Task LoadAvailableData()
		{
			
			var langues = await _viziofilmService.GetAllLanguesAsync();
			ToutesLesLangues = new ObservableCollection<LanguePiste>(langues);
			var categories = await _viziofilmService.GetAllCategoriesAsync();
			ToutesLesCategories = new ObservableCollection<Categorie>(categories);
		}
	}
}
