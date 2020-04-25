using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatv2
{
	public class Korisnik : INotifyPropertyChanged
	{
		public string Ime { get; set; }
		public ObservableCollection<string> PrimljenePoruke { get; set; } = new ObservableCollection<string>();

		public Korisnik(string i) => Ime = i;

		private Soba trenutnaSoba;
		public Soba TrenutnaSoba 
		{ 
			get => trenutnaSoba; 
			set
			{
				if (trenutnaSoba != null)
					trenutnaSoba.PosaljiPoruku -= this.PrimiPorukuOdSobe;
				trenutnaSoba = value;
				if (trenutnaSoba != null)
					trenutnaSoba.PosaljiPoruku += this.PrimiPorukuOdSobe;
			}
		}

		private string unos;
		public string Unos 
		{ 
			get => unos; 
			set
			{
				unos = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Unos"));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void PosaljiPoruku()
		{
			TrenutnaSoba.PrimiPoruku(this, Unos);
			Unos = "";
		}

		public void PrimiPorukuOdSobe(object s, PosaljiPorukuArgs a) => PrimljenePoruke.Add(
			$"{DateTime.Now}: {(s as Soba).Naziv} - {a.posiljaoc.Ime}: {a.poruka}");

	}
}
