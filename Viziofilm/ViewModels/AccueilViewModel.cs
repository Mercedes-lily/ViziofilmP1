using GestionFleur.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Viziofilm;
using Viziofilm.Core.Entities;
using Viziofilm.Core.Interfaces;
using Viziofilm.Core.Services;
using Viziofilm.Presentation.Services;

namespace Viziofilm.Presentation.ViewModels
{
	public class AccueilViewModel : INotifyPropertyChanged
	{
		private readonly IViziofilmService _viziofilmService;
		private readonly INavigationService _navigationService;

		private bool isAdmin = false;
		private bool isMembre = false;
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
		public ICommand BoutonConnectionCommande { get; private set; }
		public ICommand BoutonInscriptionCommande { get; private set; }

		private string _messageErreur;
		public string MessageErreur
		{
			get => _messageErreur;
			set { _messageErreur = value; OnPropertyChanged(); }
		}
		public Action FermerFenetre { get; set; }

		public AccueilViewModel(IViziofilmService viziofilmService, INavigationService navigationService)
		{
			_viziofilmService = viziofilmService;
			_navigationService = navigationService;
			BoutonConnectionCommande = new RelayCommand(
					o => true,
					async o => await BoutonConnectionAsync()
				);
			BoutonInscriptionCommande = new RelayCommand(
					o => true,
					o => BoutonInscription()
					);

		}

		private async Task BoutonConnectionAsync()
		{
			await VerifieAdminAsync();
			if (isAdmin)
			{
				_navigationService.NavigateToCatalogueAdministrateur();
				NomUtilisateur = "";
				MotDePasse = "";
				FermerFenetre?.Invoke();
			}
			await VerifieMembreAsync();
			if (isMembre)
			{
				_navigationService.NavigateToCatalogueMembre();
				NomUtilisateur = "";
				MotDePasse = "";
				FermerFenetre?.Invoke();
			}
			MessageErreur = "Nom d'utilisateur ou mot de passe incorrect.";
			
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private async Task VerifieMembreAsync()
		{

			var Membre = await _viziofilmService.GetMembreBynomUsagerAsync(NomUtilisateur);
			if (Membre == null || Membre.Count == 0)
			{
				isMembre = false;
				MessageErreur = "Nom d'utilisateur ou mot de passe incorrect.";
				return;
			}

			foreach (var membre in Membre)
			{
				if (membre.motDePasse == MotDePasse)
				{
					isMembre = true;
					return;
				}
			}
			isMembre = false;
			return;
		}

		private async Task VerifieAdminAsync()
		{
			var administrateurs = await _viziofilmService.GetAdministrateurBynomUsagerAsync(NomUtilisateur);

			if (administrateurs == null || administrateurs.Count == 0)
			{
				isAdmin = false;
				MessageErreur = "Combinaison incorecte";
				return;
			}

			foreach (var admin in administrateurs)
			{
				if (admin.motDePasse == MotDePasse)
				{

					isAdmin = true;
					return;
				}
			}
			isAdmin = false;
			return;
		}


		public void BoutonInscription()
		{
			_navigationService.NavigateToInscription();
			FermerFenetre?.Invoke();


		}
	}
}
