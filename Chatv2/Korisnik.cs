using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatv2
{
	public class Korisnik
	{
		public string Ime { get; set; }
		public List<string> PrimljenePoruke { get; set; }
		public string Unos { get; set; }

		public void PosaljiPoruku()
		{
			PrimljenePoruke.Add(Unos);
			Unos = "";
		}

	}
}
