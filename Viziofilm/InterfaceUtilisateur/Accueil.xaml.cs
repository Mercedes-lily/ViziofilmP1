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
using Viziofilm.Presentation.ViewModels;

namespace Viziofilm
{
	public partial class Accueil : Window
	{
		public Accueil(AccueilViewModel accueilViewModel)
		{
			InitializeComponent();
			DataContext = accueilViewModel;
			if (accueilViewModel.FermerFenetre == null)
				accueilViewModel.FermerFenetre = new Action(this.Hide);
		}
	}
}
