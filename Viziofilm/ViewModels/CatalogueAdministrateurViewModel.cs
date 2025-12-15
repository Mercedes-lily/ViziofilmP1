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
	public class CatalogueAdministrateurViewModel : INotifyPropertyChanged
	{
		private readonly IViziofilmService _viziofilmService;
		private readonly INavigationService _navigationService;
		private ObservableCollection<Film> _tousLesFilms;
		private ObservableCollection<Categorie> _toutesLesCategories;
		public ObservableCollection<Categorie> ToutesLesCategories
		{
			get => _toutesLesCategories;
			set { _toutesLesCategories = value; OnPropertyChanged(); }
		}
		public ObservableCollection<Film> TousLesFilms
		{
			get => _tousLesFilms;
			set { _tousLesFilms = value; OnPropertyChanged(); }
		}
		private Film _filmSelectionne;
		public Film FilmSelectionne
		{
			get => _filmSelectionne;
			set { _filmSelectionne = value; OnPropertyChanged(); }
		}
		public Action FermerFenetre {  get; set; }
		public ICommand BoutonGererAbonnementCommande { get; private set; }
		public ICommand BoutonStatistiqueCommande { get; private set; }
		public ICommand BoutonDeconnexionCommande { get; private set; }
		public ICommand BoutonAjouterFilmCommande { get; private set; }
		public ICommand BoutonModifierFilmCommande { get; private set; }
		public ICommand BoutonSupprimerFilmCommande { get; private set; }
		public CatalogueAdministrateurViewModel(IViziofilmService viziofilmService, INavigationService navigationService)
		{
			_viziofilmService = viziofilmService;
			_navigationService = navigationService;
			Task.Run(async () => await LoadData());
			BoutonGererAbonnementCommande = new RelayCommand(
					o => true,
					o => GererAbonnement()
				);
			BoutonStatistiqueCommande = new RelayCommand(
					o => true,
					o => Statistiques()
				);
			BoutonDeconnexionCommande = new RelayCommand(
					o => true,
					o => Deconnexion()
				);
			BoutonAjouterFilmCommande = new RelayCommand(
					o => true, 
					o =>  AjouterFilm()
				);
			BoutonModifierFilmCommande = new RelayCommand(
					o => true,
					o => ModifierFilm(o)
				);
			BoutonSupprimerFilmCommande = new RelayCommand(
				o => true,
				o => SupprimerFilmAsync(o)
				);
		}
		private void GererAbonnement()
		{
			_navigationService.NavigateToAbonnementAdministrateur();
			FermerFenetre?.Invoke();
		}
		private void Statistiques()
		{
			_navigationService.NavigateToStatistiqueAdministrateur();
			FermerFenetre?.Invoke();
		}
		private void Deconnexion()
		{
			_navigationService.NavigateToAccueil();
			FermerFenetre?.Invoke();
		}
		private void AjouterFilm()
		{
			_navigationService.NavigateToModificationFilmAdministrateur(-1);
			FermerFenetre?.Invoke();
		}
		private void ModifierFilm(Object film)
		{
			Film filmAModifier = (Film)film;
			if (filmAModifier == null)
				return;
			_navigationService.NavigateToModificationFilmAdministrateur(filmAModifier.Id);//Peutêtre une autre methode?
			FermerFenetre?.Invoke();
		}
		private async Task SupprimerFilmAsync(Object film)
		{
			Film filmASupprimer = (Film)film;
			if (filmASupprimer == null)
				return;
			string message = $"Êtes-vous sûr de vouloir supprimer le film : {filmASupprimer.Titre}?";
			var result = MessageBox.Show(message, "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if (result == MessageBoxResult.Yes)
			{
				try
				{
					await _viziofilmService.DeleteFilmAsync(filmASupprimer);

					if (TousLesFilms != null)
					{
						TousLesFilms.Remove(filmASupprimer); // Utiliser l'objet passé en paramètre
					}

					MessageBox.Show("Le film a été supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Erreur lors de la suppression du film : {ex.Message} ! La suppression a été annulée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		private async Task LoadData()
		{
			var films = await _viziofilmService.GetAllFilmsAsync();
			TousLesFilms = new ObservableCollection<Film>(films);
			var categories = await _viziofilmService.GetAllCategoriesAsync();
			ToutesLesCategories = new ObservableCollection<Categorie>(categories);
		}
	}
}
