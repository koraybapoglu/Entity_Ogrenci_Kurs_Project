using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.Entities
{
	public class Ogrenci
	{
		public int OgrenciID { get; set; }
		public string OgrenciAdi { get; set; }
		public string OgrenciSoyadi { get; set; }
		public DateTime OgrenciDogumTarihi { get; set; }
		public string OgrenciEmail { get; set; }

		// Öğrenci ile öğrenci-kurs ilişkisi
		public ICollection<OgrenciKurs> OgrenciKurslar { get; set; }
	}
}
