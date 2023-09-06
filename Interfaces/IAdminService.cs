using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.Interfaces
{
	internal interface IAdminService
	{
		public Task OgrencilerGetir();
		public Task OgrenciGetir();
		public Task OgrenciSayisiGetir();
		public Task OgrenciGruplariGetir();
		public Task OgrenciKursKayit();
		public Task OgrenciKursSil();
		public Task OgrenciKursGuncelle();
		public Task OgretmenleriGetir();
		public Task OgretmenGetir();
		public Task OgretmenSayiGetir();
		public Task DersleriGetir();
		public Task DersGetir();
		public Task DersSayiGetir();
		public Task KurslariGetir();
		public Task KursGetir();
		public Task KursSayiGetir();
		public Task MaxKursGetir();
		public Task MınKursGetir();
		public Task KursGruplariGetir();
		public Task KursaKayıtOlmayanOgrenci();
    }
}
