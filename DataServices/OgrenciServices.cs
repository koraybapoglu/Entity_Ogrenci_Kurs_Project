using Entity_Ogrenci_Kurs_Project.Entities;
using Entity_Ogrenci_Kurs_Project.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.DataServices
{
	public class OgrenciServices : ICrudService<Ogrenci>
	{
		public OgrenciServices()
		{
			Console.Clear();
		}
		public async Task GetByIdAsync(int id)
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					var ogr = (from Ogrenci in context.Ogrenciler
							   where Ogrenci.OgrenciID == id
							   select Ogrenci);
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
			}
			catch (Exception ex)
			{

				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task GetAllAsync()
		{
			List<Ogrenci> ogrenciler = null;
			using (var context = new OgrenciKursDbContext())
			{
				try
				{
					ogrenciler = await (from Ogrenci in context.Ogrenciler
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
				catch (Exception ex)
				{
					Console.WriteLine("Hata Oluştu: " + ex.Message);
				}
			}
		}
		public async Task AddAsync()
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
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					await context.Ogrenciler.AddAsync(addogrenci);
					await context.SaveChangesAsync();
				}

				Console.Clear();
				Console.WriteLine("Başarılı Bir Şekilde Öğrenci Eklendi !");
			}
			catch (Exception ex)
			{

				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task UpdateAsync()
		{
			await GetAllAsync();
			Console.WriteLine("Lütfen Öğrenci NO Giriniz:");
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					Ogrenci ogr = await context.Ogrenciler.FirstOrDefaultAsync(o => o.OgrenciID == int.Parse(Console.ReadLine()));
					Console.Clear();
					await GetByIdAsync(ogr.OgrenciID);
					Console.WriteLine("Lütfen Üyenin Yeni Adını Giriniz:");
					ogr.OgrenciAdi = Console.ReadLine();
					Console.WriteLine("Lütfen Üyenin Yeni Soyadını Giriniz:");
					ogr.OgrenciSoyadi = Console.ReadLine();
					Console.WriteLine("Lütfen Üyenin Yeni Doğum Tarihini Giriniz:");
					ogr.OgrenciDogumTarihi = Convert.ToDateTime(Console.ReadLine());
					Console.WriteLine("Lütfen Üyenin Yeni E-Mail Adresini Giriniz:");
					ogr.OgrenciEmail = Console.ReadLine();
					await context.SaveChangesAsync();
					Console.WriteLine("Başarılı Bir Şekilde Üye Güncellendi !");
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
			Ogrenci silienecekogrenci = new();
			Console.WriteLine("Silinecek olan Üyenin NO Giriniz:");
			silienecekogrenci.OgrenciID = int.Parse(Console.ReadLine());
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					context.Ogrenciler.Remove(silienecekogrenci);
					await context.SaveChangesAsync();
				}
				Console.WriteLine("Öğrenci Başarıyla Silindi !");
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
					Console.WriteLine(await (from ogrenci in context.Ogrenciler
											 select ogrenci).CountAsync());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task OgrenciGruplariGetir()
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					var ogrenciKursBirlesimi = from ogrenci in context.Ogrenciler
											   join kayit in context.Ogrenci_Kurslar
											   on ogrenci.OgrenciID equals kayit.OgrenciID
											   join kurs in context.Kurslar
											   on kayit.KursID equals kurs.KursID
											   select new
											   {
												   OgrenciAdi = ogrenci.OgrenciAdi,
												   OgrenciSoyadi = ogrenci.OgrenciSoyadi,
												   KursAdi = kurs.KursAdi
											   };
					foreach (var kayit in ogrenciKursBirlesimi)
					{
						Console.WriteLine($"Öğrenci Adı: {kayit.OgrenciAdi}, Öğrenci Soyadı: {kayit.OgrenciSoyadi}, Kurs Adı: {kayit.KursAdi}");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
	}
}

