using Entity_Ogrenci_Kurs_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.DataServices
{
	public class OgrenciServices
	{
		public OgrenciServices()
		{
			Console.Clear();
		}
		OgrenciKursDbContext context = new();
		public async void OgrenciEkle()
		{
			Ogrenci addogrenci = new();
			Console.WriteLine("Lütfen Öğrencinin Adını Giriniz:");
			addogrenci.OgrenciAdi = Console.ReadLine();
			Console.WriteLine("Lütfen Öğrencinin Soyadını Giriniz:");
			addogrenci.OgrenciSoyadi = Console.ReadLine();
			Console.WriteLine("Lütfen Öğrencinin Doğum Tarihini Giriniz:");
			addogrenci.OgrenciDogumTarihi = Convert.ToDateTime(Console.ReadLine());
			Console.WriteLine("Lütfen Öğrencinin E-mail Giriniz:");
			addogrenci.OgrenciEmail = Console.ReadLine();
			context.Ogrenciler.AddAsync(addogrenci);
			context.SaveChangesAsync();
		}
		public async void OgrenciSil()
		{
			Console.Clear();
			OgrencileriGetir();
			Ogrenci silienecekogrenci = new();
			Console.WriteLine("Silinecek olan Üyenin NO Giriniz:");
			silienecekogrenci.OgrenciID = int.Parse(Console.ReadLine());
			if (silienecekogrenci != null)
			{
				context.Ogrenciler.Remove(silienecekogrenci);
				context.SaveChangesAsync();
				Console.WriteLine("Öğrenci Başarıyla Silindi !");
			}
			else
			{
				Console.WriteLine("Böyle Bir Öğrenci Bulunamadı !");
			}
		}
		public async void OgrencileriGetir()
		{
			var ogrenciler = await (from Ogrenci in context.Ogrenciler
									select Ogrenci).ToListAsync();
			foreach (var item in ogrenciler)
			{
				Console.WriteLine("--------------------------------\n" +
								  $"Öğrenci NO: {item.OgrenciID}\n" +
								  $"Öğrenci Adı: {item.OgrenciAdi}\n" +
								  $"Öğrenci Soyadı: {item.OgrenciSoyadi}\n" +
								  $"Öğrenci Doğum Tarihi: {item.OgrenciDogumTarihi}\n" +
								  $"Öğrenci Email: {item.OgrenciEmail}\n" +
								  "----------------------------------\n");
			}
		}
		public async void OgrenciGuncelle()
		{
			OgrencileriGetir();
			Console.WriteLine("Lütfen Öğrenci NO Giriniz:");
			Ogrenci ogr = await context.Ogrenciler.FirstOrDefaultAsync(o => o.OgrenciID == int.Parse(Console.ReadLine()));
			Console.Clear();
			if (ogr != null)
			{
				OgrenciGetir(ogr.OgrenciID);
				Console.WriteLine("Lütfen Üyenin Yeni Adını Giriniz:");
				ogr.OgrenciAdi = Console.ReadLine();
				Console.WriteLine("Lütfen Üyenin Yeni Soyadını Giriniz:");
				ogr.OgrenciSoyadi = Console.ReadLine();
				Console.WriteLine("Lütfen Üyenin Yeni Doğum Tarihini Giriniz:");
				ogr.OgrenciDogumTarihi = Convert.ToDateTime(Console.ReadLine());
				Console.WriteLine("Lütfen Üyenin Yeni E-Mail Adresini Giriniz:");
				ogr.OgrenciEmail = Console.ReadLine();
				if (ogr != null)
				{
					context.SaveChangesAsync();
					Console.WriteLine("Başarılı Bir Şekilde Üye Güncellendi !");
				}
				else
				{
					Console.WriteLine("Güncelleme İşlemi Başarısız Lütfen Tekrar Deneyiniz !");
				}

			}
		}
		public void OgrenciGetir(int OgrenciID)
		{
			var ogr = (from Ogrenci in context.Ogrenciler
					   where Ogrenci.OgrenciID == OgrenciID
					   select Ogrenci);
			if (ogr != null)
			{
				foreach (var item in ogr)
				{
					Console.WriteLine("----------------------------------------\n" +
									  $"Öğrencinin Adı: {item.OgrenciAdi}\n" +
									  $"Öğrencinin Soyadı: {item.OgrenciSoyadi}\n" +
									  $"Öğrencinin Doğum Tarihi: {item.OgrenciDogumTarihi}\n" +
									  $"Öğrencinin E-Mail Adresi: {item.OgrenciEmail}\n" +
									  "----------------------------------------\n");
				}
			}
			else
			{
				Console.WriteLine("Öğrenci Bulma Başarısız Oldu Lütfen Daha Sonra Tekrar Deneyiniz !");
			}

		}
	}
}
