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
					o => BoutonEnregistrerFilm()
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

		private async void BoutonEnregistrerFilm()
		{
			bool estNouveau = FilmSelectionne == null;
			Film filmAEnregistrer;
			if (Titre == null || AnneeSortie == 0 || Duree == 0 || Synopsis == null || MotsCles == null || CategorieSelectionnee == null || LanguePisteSelectionnee == null)
			{
				MessageErreur = "Veuillez Remplir tous les champs.";
				return;
			}
			if (estNouveau)
			{
				filmAEnregistrer = new Film();
			}
			else
			{
				filmAEnregistrer = FilmSelectionne;
			}
			filmAEnregistrer.Statut = StatutSelectionne;
			filmAEnregistrer.Titre = Titre;
			filmAEnregistrer.AnneeSortie = AnneeSortie;
			filmAEnregistrer.Duree = Duree;
			filmAEnregistrer.Prix = Prix;
			filmAEnregistrer.Synopsis = Synopsis;
			filmAEnregistrer.MotsCles = MotsCles;
			//Problème d'implémentation de Many-to-Many à régler si temps. Ne s'effectue pas comme ça mais plutôt avec la table CategorieFilm
			//filmAEnregistrer.Categories.Clear();
			//filmAEnregistrer.Categories.Add(CategorieSelectionnee);
			//filmAEnregistrer.LanguePistes.Clear();
			//filmAEnregistrer.LanguePistes.Add(LanguePisteSelectionnee);
			try
			{
				if (estNouveau)
				{
					await _viziofilmService.AddFilmAsync(filmAEnregistrer);
					MessageBox.Show("Le film a été ajouté avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				else
				{
					await _viziofilmService.UpdateFilmAsync(filmAEnregistrer);
					MessageBox.Show("Le film a été mis à jour avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				_navigationService.NavigateToCatalogueAdministrateur();
				FermerFenetre?.Invoke();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Erreur d'enregistrement : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
				MessageErreur = $"Erreur : {ex.Message}";
			}
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
				FilmSelectionne = film;
				InitFilm(film);
			}
			else
			{
				FilmSelectionne = null;
			}
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
		public async Task LoadAvailableData()
		{
			
			var langues = await _viziofilmService.GetAllLanguesAsync();
			ToutesLesLangues = new ObservableCollection<LanguePiste>(langues);
			var categories = await _viziofilmService.GetAllCategoriesAsync();
			ToutesLesCategories = new ObservableCollection<Categorie>(categories);
		}
	}
}
