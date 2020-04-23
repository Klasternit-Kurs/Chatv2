using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatv2
{
	public class Korisnik : INotifyPropertyChanged
	{
		public string Ime { get; set; }
		public List<string> PrimljenePoruke { get; set; } = new List<string>();

		private Soba trenutnaSoba;
		public Soba TrenutnaSoba 
		{ 
			get => trenutnaSoba; 
			set
			{
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
			$"{(s as Soba).Naziv} - {a.posiljaoc.Ime}: {a.poruka}");

	}
}
