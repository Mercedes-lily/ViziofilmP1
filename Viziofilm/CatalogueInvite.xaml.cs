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

namespace Viziofilm
{
    /// <summary>
    /// Logique d'interaction pour CatalogueInvite.xaml
    /// </summary>
    public partial class CatalogueInvite : Window
    {
        public CatalogueInvite()
        {
            InitializeComponent();
        }

		private void BtnInscription_Click(object sender, RoutedEventArgs e)
		{
			Inscription nouvelleFenetre = new Inscription();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnRechercheCatalogue_Click(object sender, RoutedEventArgs e)
		{
			CatalogueInvite nouvelleFenetre = new CatalogueInvite();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnRechercheAvanceeCatalogue_Click(object sender, RoutedEventArgs e)
		{
			RechercheAvancee nouvelleFenetre = new RechercheAvancee();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnRetour_Click(object sender, RoutedEventArgs e)
		{
			Accueil nouvelleFenetre = new Accueil();

			nouvelleFenetre.Show();

			this.Close();
		}
	}
}
