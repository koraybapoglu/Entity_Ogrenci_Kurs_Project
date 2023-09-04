using Entity_Ogrenci_Kurs_Project.Entities;
using Entity_Ogrenci_Kurs_Project.MenuServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.DataServices
{
	public class OgretmenServices
	{
		OgrenciKursDbContext context = new();
		public void OgretmenEkle()
		{
			Ogretmen ogretekle = new();
			Console.WriteLine("Lütfen Eklemek İstediğiniz Öğretmenin Adını Giriniz:");
			ogretekle.OgretmenAdi = Console.ReadLine();
			Console.WriteLine("Lütfen Eklemek İstediğiniz Öğretmenin Soyadını Giriniz:");
			ogretekle.OgretmenSoyadi = Console.ReadLine();
			Console.WriteLine("Lütfen Eklemek İstediğiniz Öğretmenin Doğum Tarihini Giriniz:");
			ogretekle.OgretmenDogumTarihi = Convert.ToDateTime(Console.ReadLine());
			if (ogretekle != null)
			{
				context.Ogretmenler.AddAsync(ogretekle);
				context.SaveChanges();
			}
			else
			{
				Console.WriteLine("Öğretmen Eklenirken Bir Hata Meydana Geldi Lütfen Tekrar Deneyiniz !");
			}
		}
		public async void OgretmenleriGetir()
		{
			var ogretmenler = await (from Ogretmen in context.Ogretmenler
									 select Ogretmen).ToListAsync();
			if (ogretmenler != null)
			{
				foreach (var item in ogretmenler)
				{
					Console.WriteLine($"-----------------------------------------------------\n" +
						$"Öğretmen NO: {item.OgretmenID}\n" +
						$"Öğretmen Adı: {item.OgretmenAdi}\n" +
						$"Öğretmen Soyadı: {item.OgretmenSoyadi}\n" +
						$"Öğretmen E-Mail: {item.OgretmenEmail}\n" +
						$"Öğretmen Doğum Tarihi: {item.OgretmenDogumTarihi}\n" +
						$"-----------------------------------------------------\n");
				}
			}
			else
			{
				Console.WriteLine("Öğretmenleri Getirirken Bir Hata Oluştu Lütfen Tekrar Deneyiniz !");
			}
		}
		public async void OgretmenGetir(int OgretmenID)
		{
			var ogretmen = await (from Ogretmen in context.Ogretmenler
								  where Ogretmen.OgretmenID == OgretmenID
								  select Ogretmen).ToListAsync();
			if (ogretmen != null)
			{
				foreach (var item in ogretmen)
				{
					Console.WriteLine($"-----------------------------------------------------\n" +
						$"Öğretmen NO: {item.OgretmenID}\n" +
						$"Öğretmen Adı: {item.OgretmenAdi}\n" +
						$"Öğretmen Soyadı: {item.OgretmenSoyadi}\n" +
						$"Öğretmen E-Mail: {item.OgretmenEmail}\n" +
						$"Öğretmen Doğum Tarihi: {item.OgretmenDogumTarihi}\n" +
						$"-----------------------------------------------------\n");
				}
			}
			else
			{
				Console.WriteLine("İstediğiniz Öğretmen Buluanamadı !");
			}
		}
		public async void OgretmenSil()
		{
			OgretmenleriGetir();
			Ogretmen ogretmensil = new();
			Console.WriteLine("Lütfen Silmek İstediğiniz Öğretmenin NO Giriniz:");
			ogretmensil.OgretmenID = int.Parse(Console.ReadLine());
			if (ogretmensil != null)
			{
				context.Ogretmenler.Remove(ogretmensil);
				context.SaveChanges();
				Console.WriteLine("Öğretmen Başarılı Bir Şekilde Silindi !");
			}
			else
			{
				Console.WriteLine("Girmiş Olduğunuz Numaralı Öğretmen Bulunamadı !");
			}
		}
		public async void OgretmenGuncelle()
		{
			OgretmenleriGetir();

			Console.WriteLine("Lütfen Güncellemek İstediğiniz Öğrencinin Numarasını Giriniz:");
			Ogretmen guncellenecekogretmen = context.Ogretmenler.FirstOrDefault(o => o.OgretmenID == int.Parse(Console.ReadLine()));
			Console.Clear();
			await Console.Out.WriteLineAsync("Seçili Öğretmen:" + "\n\n");
			OgretmenGetir(guncellenecekogretmen.OgretmenID);
			Console.WriteLine("Lütfen Öğretmenin Yeni Adını Giriniz:");
			guncellenecekogretmen.OgretmenAdi = Console.ReadLine();
			Console.WriteLine("Lütfen Öğretmenin Yeni Soyadını Giriniz:");
			guncellenecekogretmen.OgretmenSoyadi = Console.ReadLine();
			Console.WriteLine("Lütfen Öğretmenin Yeni E-mail Giriniz:");
			guncellenecekogretmen.OgretmenEmail = Console.ReadLine();
			Console.WriteLine("Lütfen Öğretmenin Yeni Doğum Tarihini Giriniz:");
			guncellenecekogretmen.OgretmenDogumTarihi = Convert.ToDateTime(Console.ReadLine());
			if (guncellenecekogretmen != null)
			{
				await context.SaveChangesAsync();
			}
			else
			{
				Console.WriteLine("Bir Hata İle Karşılaşıldı !");
			}
		}
	}
}
