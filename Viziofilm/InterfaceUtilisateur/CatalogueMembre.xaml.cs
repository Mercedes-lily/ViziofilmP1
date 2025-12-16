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
using Viziofilm.Presentation.ViewModels;

namespace Viziofilm
{
    /// <summary>
    /// Logique d'interaction pour CatalogueMembre.xaml
    /// </summary>
    public partial class CatalogueMembre : Window
    {

		public CatalogueMembre(CatalogueMembreViewModel catalogueMembreViewModel)
        {
            InitializeComponent();
			DataContext = catalogueMembreViewModel;
			if (catalogueMembreViewModel.FermerFenetre == null)
			{
				catalogueMembreViewModel.FermerFenetre = new Action(this.Close);
			}
		}
	}
}
