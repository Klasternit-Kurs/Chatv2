using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chatv2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ObservableCollection<Soba> Sobe = new ObservableCollection<Soba>();

		public MainWindow()
		{
			InitializeComponent();
			Sobe.Add(new Soba("Probna"));
			Sobe.Add(new Soba("Soba1"));
			Sobe.Add(new Soba("Soba2"));
			Sobe.Add(new Soba("Soba3"));
			cmb.ItemsSource = Sobe;
			cmb.DisplayMemberPath = "Naziv";
			cmb.SelectedIndex = 0;
		}

		private void Posalji(object sender, RoutedEventArgs e)
		{
			//(this.Resources["k1"] as Korisnik).PosaljiPoruku();
			((sender as Control).DataContext as Korisnik).PosaljiPoruku();
			ic.ItemsSource = ((sender as Control).DataContext as Korisnik).PrimljenePoruke.ToList();
		}

		private void PromenaSoba(object sender, SelectionChangedEventArgs e)
		{
			//if ((sender as ComboBox).SelectedItem != null)
			//	((sender as Control).DataContext as Korisnik).TrenutnaSoba = (sender as ComboBox).SelectedItem as Soba;
		}
	}
}
