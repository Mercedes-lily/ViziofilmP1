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
    /// Logique d'interaction pour ProfilMembre.xaml
    /// </summary>
    public partial class ProfilMembre : Window
    {
        public ProfilMembre()
        {
            InitializeComponent();
        }

		private void BtnPorteFeuille_Click(object sender, RoutedEventArgs e)
		{
			PortefeuilleMembre nouvelleFenetre = new PortefeuilleMembre();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnCatalogue_Click(object sender, RoutedEventArgs e)
		{
			CatalogueMembre nouvelleFenetre = new CatalogueMembre();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnAbonnement_Click(object sender, RoutedEventArgs e)
		{
			AbonnementMembre nouvelleFenetre = new AbonnementMembre();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnModifierProfil_Click(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void BtnModifierPreference_Click(object sender, RoutedEventArgs e)
		{
			return;
		}
	}
}
