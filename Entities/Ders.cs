using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.Entities
{
	public class Ders
	{
		public int DersID { get; set; }
		public string DersAdi { get; set; }
		public string DersAciklama { get; set; }
		public DateTime AcilisTarihi { get; set; }
		public int OgretmenID { get; set; }

		// Ders ile öğretmen arasındaki ilişki
		public Ogretmen Ogretmen { get; set; }
	}
}
