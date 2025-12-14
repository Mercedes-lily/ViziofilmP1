using GestionFleur.ViewModels;
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

public class AccueilViewModel : INotifyPropertyChanged
{
	private bool isAdmin = false;
	private bool isMembre = false;
	private readonly IViziofilmService _viziofilmService;
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

	public AccueilViewModel(IViziofilmService viziofilmService)
	{
		_viziofilmService = viziofilmService;
		BoutonConnectionCommande = new RelayCommand(
				o => true,
				o => BoutonConnection()
			);
		BoutonInscriptionCommande = new RelayCommand(
				o => true,
				o => BoutonInscription()
				);

	}

	private void BoutonConnection()
	{
		VerifieAdmin();
		//VerifieMembre();
		if (isAdmin)
		{
			CatalogueAdministrateur inscription = new CatalogueAdministrateur();
			inscription.Show();
			return;
		}
		//else if(isMembre)
		//{
		//	CatalogueMembre inscription = new CatalogueMembre();
		//		inscription.Show();
		//	return;
		//}
		else
		{
			MessageErreur = "Nom d'utilisateur ou mot de passe incorrect.";
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;
	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	private async void VerifieMembre()
	{

		var Membre = await _viziofilmService.GetMembreBynomUsager(NomUtilisateur);
		if (Membre == null || Membre.Count == 0)
		{
			isMembre = false;
			MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
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

	private async void VerifieAdmin()
	{
			MessageBox.Show("Vérification administrateur en cours...");
		var administrateurs = await _viziofilmService.GetAdministrateurBynomUsager(NomUtilisateur);

		if (administrateurs == null || administrateurs.Count == 0)
		{
			isAdmin = false;
			MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
			MessageErreur = "Nom d'utilisateur ou mot de passe incorrect.";
			return;
		}

		foreach (var admin in administrateurs)
	{
			MessageBox.Show(admin.nomUsager);
			MessageBox.Show(MotDePasse);

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
		Inscription inscription = new Inscription();
		inscription.Show();


	}
}

