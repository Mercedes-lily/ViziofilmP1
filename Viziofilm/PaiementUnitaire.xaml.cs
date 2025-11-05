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
    /// Logique d'interaction pour PaiementUnitaire.xaml
    /// </summary>
    public partial class PaiementUnitaire : Window
    {
        public PaiementUnitaire()
        {
            InitializeComponent();
        }

		private void SoumettreButton_Click(object sender, RoutedEventArgs e)
		{
            return;
		}

		private void RetourFilmButton_Click(object sender, RoutedEventArgs e)
		{
			Film nouvelleFenetre = new Film();

			nouvelleFenetre.Show();

			this.Close();
		}
	}
}
