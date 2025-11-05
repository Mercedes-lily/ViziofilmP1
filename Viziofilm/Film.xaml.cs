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
    /// Logique d'interaction pour Film.xaml
    /// </summary>
    public partial class Film : Window
    {
        public Film()
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

		private void AbonnementVisionner_Click(object sender, RoutedEventArgs e)
		{
			PaiementUnitaire nouvelleFenetre = new PaiementUnitaire();

			nouvelleFenetre.Show();

			this.Close();
		}
	}
}
