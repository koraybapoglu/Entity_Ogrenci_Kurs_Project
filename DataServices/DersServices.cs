using Entity_Ogrenci_Kurs_Project.Entities;
using Entity_Ogrenci_Kurs_Project.MenuServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.DataServices
{
	internal class DersServices
	{
		OgrenciKursDbContext context = new();
		public async void DersEkle()
		{
			Ders dersekle = new();
			Console.WriteLine("Lütfen Dersin Adını Giriniz:");
			dersekle.DersAdi = Console.ReadLine();
			Console.WriteLine("Lütfen Dersin Açıklamasını Giriniz:");
			dersekle.DersAciklama = Console.ReadLine();
			dersekle.AcilisTarihi = DateTime.Now;
			OgretmenServices ogretservices = new();
			ogretservices.OgretmenleriGetir();
			Console.WriteLine("Lütfen Dersin Öğretmenin NO Giriniz:");
			dersekle.OgretmenID = int.Parse(Console.ReadLine());
			if (dersekle != null)
			{
				await context.Dersler.AddAsync(dersekle);
				context.SaveChanges();
				Console.WriteLine("Ders Ekleme İşlemi Başarılı Bir Şekilde Gerçekleştirildi !");
			}
			else
			{
				Console.WriteLine("Ders Ekleme Başarısız Lütfen Tekrar Deneyiniz.");
			}
		}
		public async void DerslerGetir()
		{
			var derslergetir = context.Dersler.Join
					  (context.Ogretmenler,
					  D => D.OgretmenID,
					  O => O.OgretmenID,
					  (D, O) => new
					  {
						  DersID = D.DersID,
						  DersAdi = D.DersAdi,
						  DersAciklama = D.DersAciklama,
						  DersBaslangicTarihi = D.AcilisTarihi,
						  OgretmenAdi = O.OgretmenAdi,
						  OgretmenSoyadi = O.OgretmenSoyadi,

					  }).ToList();

			if (derslergetir != null)
			{
				foreach (var item in derslergetir)
				{
					Console.WriteLine("--------------------------------------------\n" +
									  $"Ders NO: {item.DersID}\n" +
									  $"Ders Adı: {item.DersAdi}\n" +
									  $"Ders Aciklama: {item.DersAciklama}\n" +
									  $"Ders Yüklenme Tarihi: {item.DersBaslangicTarihi}\n" +
									  $"Ders Öğretmeni Adı: {item.OgretmenAdi}\n" +
									  $"Ders Öğretmeni Soyadı: {item.OgretmenSoyadi}\n" +
									  "--------------------------------------------\n");
				}
			}
			else
			{
				Console.WriteLine("Dersler Getirilirken Hata Meydana Geldi !");
			}
		}
		public async void DersGetir(int DersID)
		{
			var ders = await (from Ders in context.Dersler
							  where Ders.DersID == DersID
							  join Ogretmen in context.Ogretmenler on Ders.OgretmenID equals Ogretmen.OgretmenID
							  select new
							  {
								  Ders.DersID,
								  Ders.DersAdi,
								  Ders.DersAciklama,
								  Ders.AcilisTarihi,
								  Ogretmen.OgretmenAdi,
								  Ogretmen.OgretmenSoyadi
							  }).ToListAsync();
			if (ders != null)
			{
				foreach (var item in ders)
				{
					Console.WriteLine("--------------------------------------------\n" +
									  $"Ders NO: {item.DersID}\n" +
									  $"Ders Adı: {item.DersAdi}\n" +
									  $"Ders Aciklama: {item.DersAciklama}\n" +
									  $"Ders Yüklenme Tarihi: {item.AcilisTarihi}\n" +
									  $"Ders Öğretmeni Adı: {item.OgretmenAdi}\n" +
									  $"Ders Öğretmeni Soyadı: {item.OgretmenSoyadi}\n" +
									  "--------------------------------------------\n");
				}
			}
			else
			{
				Console.WriteLine("Hata 404:");
			}
		}
		public void DersSil() 
		{

		}
	}
}
