using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chatv2
{
	public class Logger
	{
		public void Loguj(object s, PosaljiPorukuArgs a) => File.AppendAllText
			($"{(s as Soba).Naziv}.txt", $"{DateTime.Now}: {(s as Soba).Naziv} - {a.posiljaoc.Ime}: {a.poruka}"
			+ Environment.NewLine);

	}
}
