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
    /// Logique d'interaction pour CatalogueAdministrateur.xaml
    /// </summary>
    public partial class CatalogueAdministrateur : Window
    {

		public CatalogueAdministrateur()
        {
            InitializeComponent();
        }

		private void BtnGererAbonnement_Click(object sender, RoutedEventArgs e)
		{
			AbonnementAdministrateur nouvelleFenetre = new AbonnementAdministrateur();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnStatistiques_Click(object sender, RoutedEventArgs e)
		{
			StatistiqueAdministrateur nouvelleFenetre = new StatistiqueAdministrateur();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnDeconexion_Click(object sender, RoutedEventArgs e)
		{
			//Accueil nouvelleFenetre = new Accueil();

			//nouvelleFenetre.Show();

			this.Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			return;
		}
	}
}
