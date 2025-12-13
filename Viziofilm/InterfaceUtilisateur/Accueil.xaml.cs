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
using Viziofilm.Core.Entities;
using Viziofilm.Core.Services;

namespace Viziofilm
{
	/// <summary>
	/// Logique d'interaction pour Accueil.xaml
	/// </summary>
	public partial class Accueil : Window
	{
		public Accueil()
		{
			InitializeComponent();
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
