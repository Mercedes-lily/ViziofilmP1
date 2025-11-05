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
	/// Logique d'interaction pour Inscription.xaml
	/// </summary>
	public partial class Inscription : Window
	{
		public Inscription()
		{
			InitializeComponent();
		}

		private void BtnInscription_Click(object sender, RoutedEventArgs e)
		{
			return; //Créer un utilisateur
		}

		private void BtnRetour_Click(object sender, RoutedEventArgs e)
		{
			Accueil nouvelleFenetre = new Accueil();

			nouvelleFenetre.Show();

			this.Close();
		}

	}
}
