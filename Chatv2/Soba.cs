using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatv2
{
	public class PosaljiPorukuArgs
	{
		public string poruka;
		public Korisnik posiljaoc;
		public PosaljiPorukuArgs(string p, Korisnik kor)
		{
			poruka = p;
			posiljaoc = kor;
		}
	}

	public class Soba
	{
		public string Naziv { get; set; }

		public delegate void PosaljiPorukuHandler(object soba, PosaljiPorukuArgs a);
		public event PosaljiPorukuHandler PosaljiPoruku;

		public void PrimiPoruku(Korisnik k, string p) => PosaljiPoruku?.Invoke(this, new PosaljiPorukuArgs(p, k));

		public Soba(string s) => Naziv = s;
	}
}
