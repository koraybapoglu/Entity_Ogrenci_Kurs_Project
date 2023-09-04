using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.Entities
{
	public class Ogretmen
	{
		public int OgretmenID { get; set; }
		public string OgretmenAdi { get; set; }
		public string OgretmenSoyadi { get; set; }
		public DateTime OgretmenDogumTarihi { get; set; }
		public string OgretmenEmail { get; set; }

		// Ogretmen ile ders ilişkisi
		public ICollection<Ders> Dersler { get; set; }
		// Ogretmen ile kurs ilişkisi
		public ICollection<Kurs> Kurslar { get; set; }
	}
}
