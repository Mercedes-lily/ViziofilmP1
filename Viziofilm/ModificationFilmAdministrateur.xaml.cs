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
	/// Logique d'interaction pour ModificationFilmAdministrateur.xaml
	/// </summary>
	public partial class ModificationFilmAdministrateur : Window
	{
		public ModificationFilmAdministrateur()
		{
			InitializeComponent();
		}

		private void BtnEnregristrerFilm_Click(object sender, RoutedEventArgs e)
		{
			CatalogueAdministrateur nouvelleFenetre = new CatalogueAdministrateur();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void BtnAnnulerFilm_Click(object sender, RoutedEventArgs e)
		{
			CatalogueAdministrateur nouvelleFenetre = new CatalogueAdministrateur();

			nouvelleFenetre.Show();

			this.Close();
		}
	}
}
