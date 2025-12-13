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
    /// Logique d'interaction pour AbonnementMembre.xaml
    /// </summary>
    public partial class AbonnementMembre : Window
    {

		public AbonnementMembre( )
        {
            InitializeComponent();
        }

		private void BtnSupendreAbonnement_Click(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void BtnReprendreAbonnement_Click(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void BtnAnnulerPlan_Click(object sender, RoutedEventArgs e)
		{
			return;
		}

		private void BtnCatalogue_Click(object sender, RoutedEventArgs e)
		{
			CatalogueMembre nouvelleFenetre = new CatalogueMembre();

			nouvelleFenetre.Show();

			this.Close();
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
	}
}
