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
using Viziofilm.Core.Services;

namespace Viziofilm
{
	/// <summary>
	/// Logique d'interaction pour Accueil.xaml
	/// </summary>
	public partial class Accueil : Window
	{
		public Accueil(AccueilViewModel accueilViewModel)
		{
			InitializeComponent();
			// Créez une instance de votre ViewModel et affectez-la au DataContext
			this.DataContext = accueilViewModel;
		}
	}
}
