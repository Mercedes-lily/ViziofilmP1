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
    /// Logique d'interaction pour StatistiqueAdministrateur.xaml
    /// </summary>
    public partial class StatistiqueAdministrateur : Window
    {

		public StatistiqueAdministrateur( )
        {
            InitializeComponent();
        }

		private void BtnGererCatalogue_Click(object sender, RoutedEventArgs e)
		{
			CatalogueAdministrateur nouvelleFenetre = new CatalogueAdministrateur();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnGererAbonnement_Click(object sender, RoutedEventArgs e)
		{
			AbonnementAdministrateur nouvelleFenetre = new AbonnementAdministrateur();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnDeconexion_Click(object sender, RoutedEventArgs e)
		{
			//Accueil nouvelleFenetre = new Accueil();

			//nouvelleFenetre.Show();

			this.Close();
		}
	}
}
