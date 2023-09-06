using Entity_Ogrenci_Kurs_Project.Entities;
using Entity_Ogrenci_Kurs_Project.Interfaces;
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
	internal class DersServices : ICrudService<Ders>
	{
		OgretmenServices _ogretmenservices = new();
		public async Task AddAsync()
		{
			Ders dersekle = new();
			Console.WriteLine("Lütfen Dersin Adını Giriniz:");
			dersekle.DersAdi = Console.ReadLine();
			Console.WriteLine("Lütfen Dersin Açıklamasını Giriniz:");
			dersekle.DersAciklama = Console.ReadLine();
			dersekle.AcilisTarihi = DateTime.Now;
			await _ogretmenservices.GetAllAsync();
			Console.WriteLine("Lütfen Dersin Öğretmenin NO Giriniz:");
			dersekle.OgretmenID = int.Parse(Console.ReadLine());
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					await context.Dersler.AddAsync(dersekle);
					await context.SaveChangesAsync();
					Console.WriteLine("Ders Ekleme İşlemi Başarılı Bir Şekilde Gerçekleştirildi !");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task UpdateAsync()
		{
			await GetAllAsync();
			Ders dersguncelle = new();
			Console.WriteLine("Lütfen Güncellemek İstediğiniz Dersin NO Giriniz:");
			dersguncelle.DersID = int.Parse(Console.ReadLine());
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}

		public async Task DeleteAsync()
		{
			Console.Clear();
			await GetAllAsync();
			Ders derssil = new();
			Console.WriteLine("Lütfen Silinecek Olan Dersin NO Giriniz:");
			derssil.DersID = int.Parse(Console.ReadLine());
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					context.Dersler.Remove(derssil);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}

		public async Task GetByIdAsync(int id)
		{

			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					var ders = await (from Ders in context.Dersler
									  where Ders.DersID == id
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
			}
			catch (Exception ex)
			{

				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}

		public async Task GetAllAsync()
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					var derslergetir = await context.Dersler.Join
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

						 }).ToListAsync();
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
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}

		public async Task GetCountAsync()
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					Console.WriteLine(await (from Ders in context.Dersler
											 select Ders).CountAsync());
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
	}
}
