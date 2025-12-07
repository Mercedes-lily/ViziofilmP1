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
	/// Logique d'interaction pour ModificationAbonnementAdministrateur.xaml
	/// </summary>
	public partial class ModificationAbonnementAdministrateur : Window
	{
		public ModificationAbonnementAdministrateur()
		{
			InitializeComponent();
		}

		private void BtnAnnulerAbonnement_Click(object sender, RoutedEventArgs e)
		{
			AbonnementAdministrateur nouvelleFenetre = new AbonnementAdministrateur();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnEnregristrerAbonnement_Click(object sender, RoutedEventArgs e)
		{
			AbonnementAdministrateur nouvelleFenetre = new AbonnementAdministrateur();

			nouvelleFenetre.Show();

			this.Close();
		}
	}
}
