using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.Interfaces
{
	public interface IOgrenci_KursService
	{
		public Task OgrenciKursGuncelle();
		public Task OgrenciKursKayit();
		public Task OgrenciKursSil();
		public Task OgrenciKursGetir();
	}

}
