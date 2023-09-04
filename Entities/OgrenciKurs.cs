using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.Entities
{
	public class OgrenciKurs
	{
		public int OgrenciKursID { get; set; }
		public int OgrenciID { get; set; }
		public int KursID { get; set; }

		// Öğrenci-Kurs ilişkisi
		public Ogrenci Ogrenci { get; set; }
		public Kurs Kurs { get; set; }
	}
}
