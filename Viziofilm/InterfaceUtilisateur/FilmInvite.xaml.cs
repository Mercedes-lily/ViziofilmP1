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
    /// Logique d'interaction pour FilmInvite.xaml
    /// </summary>
    public partial class FilmInvite : Window
    {

		public FilmInvite()
        {
            InitializeComponent();
        }

		private void InscriptionFilmButton_Click(object sender, RoutedEventArgs e)
		{
			Inscription nouvelleFenetre = new Inscription();

			nouvelleFenetre.Show();

			this.Close();
		}

		private void RetourFilmButton_Click(object sender, RoutedEventArgs e)
		{
			CatalogueInvite nouvelleFenetre = new CatalogueInvite();

			nouvelleFenetre.Show();

			this.Close();
		}
	}
}
