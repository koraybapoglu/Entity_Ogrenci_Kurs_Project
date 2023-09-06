using Entity_Ogrenci_Kurs_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.DataServices
{
	public class AdminDataServices : IAdminService
	{
		DersServices dersservices = new();
		OgretmenServices OgretmenServices = new();
		OgrenciServices OgrenciServices = new();
		KursServices KursServices = new();
		Ogrenci_KursDataServices ogrencikursServices = new();
		public async Task DersGetir()
		{
			Console.WriteLine("Lütfen Getirmek İstediğiniz Öğrencinin NO' sunu Giriniz:");
			await dersservices.GetByIdAsync(int.Parse(Console.ReadLine()));
		}

		public async Task DersleriGetir()
		{
			await dersservices.GetAllAsync();
		}

		public async Task DersSayiGetir()
		{
			await dersservices.GetCountAsync();
		}

		public async Task KursaKayıtOlmayanOgrenci()
		{
			await KursServices.KursKayitOlmayanOgrenci();
		}

		public async Task KursGetir()
		{
			Console.WriteLine("Lütfen Getirmek İstediğiniz Öğrencinin NO' sunu Giriniz:");
			await KursServices.GetByIdAsync(int.Parse(Console.ReadLine()));
		}

		public async Task KursGruplariGetir()
		{
			Console.WriteLine("Lütfen Kursun Adını Giriniz:");
			await KursServices.OgrencileriKursAdinaGoreGetir(Console.ReadLine());
		}

		public async Task KurslariGetir()
		{
			await KursServices.GetAllAsync();
		}

		public async Task KursSayiGetir()
		{
			await KursServices.GetCountAsync();
		}

		public async Task MaxKursGetir()
		{
			await KursServices.GetMaxKursAsync();
		}

		public async Task MınKursGetir()
		{
			await KursServices.GetMinKursAsync();
		}

		public async Task OgrenciGetir()
		{
			Console.WriteLine("Lütfen Öğrencinin NO Giriniz:");
			await OgrenciServices.GetByIdAsync(int.Parse(Console.ReadLine()));
		}

		public async Task OgrenciGruplariGetir()
		{
			await OgrenciServices.OgrenciGruplariGetir();
		}

		public async Task OgrenciKursGuncelle()
		{
			await ogrencikursServices.OgrenciKursGuncelle();
		}

		public async Task OgrenciKursKayit()
		{
			await ogrencikursServices.OgrenciKursKayit();
		}
		public async Task OgrenciKursGetir()
		{
			await ogrencikursServices.OgrenciKursGetir();
		}
		public async Task OgrenciKursSil()
		{
			await ogrencikursServices.OgrenciKursSil();
		}
		public async Task OgrencilerGetir()
		{
			await OgrenciServices.GetAllAsync();
		}

		public async Task OgrenciSayisiGetir()
		{
			await OgrenciServices.GetCountAsync();
		}

		public async Task OgretmenGetir()
		{
			Console.WriteLine("Lütfen Öğretmenin No Giriniz:");
			await OgretmenServices.GetByIdAsync(int.Parse(Console.ReadLine()));
		}

		public async Task OgretmenleriGetir()
		{
			await OgretmenServices.GetAllAsync();
		}

		public async Task OgretmenSayiGetir()
		{
			await OgretmenServices.GetCountAsync();
		}
	}
}
