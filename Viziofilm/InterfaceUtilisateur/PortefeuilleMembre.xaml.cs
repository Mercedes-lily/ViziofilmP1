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
    /// Logique d'interaction pour PortefeuilleMembre.xaml
    /// </summary>
    public partial class PortefeuilleMembre : Window
    {

		public PortefeuilleMembre( )
        {
            InitializeComponent();
        }

		private void BtnCatalogue_Click(object sender, RoutedEventArgs e)
		{
			//CatalogueMembre nouvelleFenetre = new CatalogueMembre();

			//nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnProfil_Click(object sender, RoutedEventArgs e)
		{
			ProfilMembre nouvelleFenetre = new ProfilMembre();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnAbonnement_Click(object sender, RoutedEventArgs e)
		{
			AbonnementMembre nouvelleFenetre = new AbonnementMembre();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnSoumettre_Click(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void BtnSoumettreCarte_Click(object sender, RoutedEventArgs e)
		{
			return;
		}
	}
}
