using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.Entities
{
	public class Kurs
	{
		public int KursID { get; set; }
		public string KursAdi { get; set; }
		public DateTime BaslangicTarihi { get; set; }
		public DateTime BitisTarihi { get; set; }

		// Kurs ile öğrenci-kurs ilişkisi
		public ICollection<OgrenciKurs> OgrenciKurslar { get; set; }
		// Kurs ile öğretmen ilişkisi
		public int OgretmenID { get; set; }
		public Ogretmen Ogretmen { get; set; }
	}
}
