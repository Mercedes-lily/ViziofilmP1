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

namespace Viziofilm
{
    /// <summary>
    /// Logique d'interaction pour CatalogueMembre.xaml
    /// </summary>
    public partial class CatalogueMembre : Window
    {

		public CatalogueMembre( )
        {
            InitializeComponent();
        }

		private void BtnProfil_Click(object sender, RoutedEventArgs e)
		{
			ProfilMembre nouvelleFenetre = new ProfilMembre();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnPorteFeuille_Click(object sender, RoutedEventArgs e)
		{
			PortefeuilleMembre nouvelleFenetre = new PortefeuilleMembre();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnAbonnement_Click(object sender, RoutedEventArgs e)
		{
			AbonnementMembre nouvelleFenetre = new AbonnementMembre();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnDeconnexion_Click(object sender, RoutedEventArgs e)
		{
			//Accueil nouvelleFenetre = new Accueil();

			//nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnRechercheCatalogue_Click(object sender, RoutedEventArgs e)
		{
			CatalogueMembre nouvelleFenetre = new CatalogueMembre();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnRechercheAvanceeCatalogue_Click(object sender, RoutedEventArgs e)
		{
			RechercheAvancee nouvelleFenetre = new RechercheAvancee();

			nouvelleFenetre.Show();

			this.Close();
		}
	}
}
