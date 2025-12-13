using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Viziofilm.Core.Interfaces;
using Viziofilm.Presentation.ViewModels;

namespace Viziofilm
{
	/// <summary>
	/// Logique d'interaction pour Accueil.xaml
	/// </summary>
	public partial class Accueil : Window
	{
		public Accueil(AccueilViewModel viewModel)
		{
			InitializeComponent();

			// Le ViewModel est assigné comme DataContext de la fenêtre
			// C'est ainsi que la fenêtre WPF sait où trouver ses données.
			DataContext = viewModel;
		}

		private void BtnInvite_Click(object sender, RoutedEventArgs e)
		{
			CatalogueInvite nouvelleFenetre = new CatalogueInvite();

			nouvelleFenetre.Show();

			this.Close();

		}

		private void BtnInscription_Click(object sender, RoutedEventArgs e)
		{
			

			Inscription nouvelleFenetre = new Inscription();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnSAuthentifier_Click(object sender, RoutedEventArgs e)
		{

			if (InputIdentifiant.Text == "admin" && InputMotDePasse.Password == "admin")
			{
				CatalogueAdministrateur nouvelleFenetre = new CatalogueAdministrateur();
				nouvelleFenetre.Show();
			}
			else
			{
				CatalogueMembre nouvelleFenetre = new CatalogueMembre();
				nouvelleFenetre.Show();
			}
			this.Close();
		}
	}
}
