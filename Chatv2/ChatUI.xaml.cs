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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chatv2
{
	/// <summary>
	/// Interaction logic for ChatUI.xaml
	/// </summary>
	public partial class ChatUI : UserControl
	{

		public Korisnik TrenutniKorisnik { get; set; }

		public ChatUI(Korisnik k, List<Soba> lst)
		{
			InitializeComponent();
			DataContext = this;
			TrenutniKorisnik = k;
			cmb.ItemsSource = lst;
			cmb.DisplayMemberPath = "Naziv";
			cmb.SelectedIndex = 0;
		}

		private void Posalji(object sender, RoutedEventArgs e)
		{
			//(this.Resources["k1"] as Korisnik).PosaljiPoruku();
			TrenutniKorisnik.PosaljiPoruku();
		}
	}
}
