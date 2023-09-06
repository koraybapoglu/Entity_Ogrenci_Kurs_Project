using Entity_Ogrenci_Kurs_Project.Entities;
using Entity_Ogrenci_Kurs_Project.Interfaces;
using Entity_Ogrenci_Kurs_Project.MenuServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.DataServices
{
	public class OgretmenServices : ICrudService<Ogretmen>
	{
		public async Task AddAsync()
		{
			Ogretmen Ogretmenekle = new();
			Console.WriteLine("Lütfen Eklemek İstediğiniz Öğretmenin Adını Giriniz:");
			Ogretmenekle.OgretmenAdi = Console.ReadLine();
			Console.WriteLine("Lütfen Eklemek İstediğiniz Öğretmenin Soyadını Giriniz:");
			Ogretmenekle.OgretmenSoyadi = Console.ReadLine();
			Console.WriteLine("Lütfen Eklemek İstediğiniz Öğretmenin Doğum Tarihini Giriniz:");
			Ogretmenekle.OgretmenDogumTarihi = Convert.ToDateTime(Console.ReadLine());
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					await context.Ogretmenler.AddAsync(Ogretmenekle);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}

		public async Task UpdateAsync()
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					await GetAllAsync();
					Console.WriteLine("Lütfen Güncellemek İstediğiniz Öğrencinin Numarasını Giriniz:");
					Ogretmen guncellenecekogretmen = await context.Ogretmenler.FirstOrDefaultAsync(o => o.OgretmenID == int.Parse(Console.ReadLine()));
					Console.Clear();
					await Console.Out.WriteLineAsync("Seçili Öğretmen:" + "\n\n");
					await GetByIdAsync(guncellenecekogretmen.OgretmenID);
					Console.WriteLine("Lütfen Öğretmenin Yeni Adını Giriniz:");
					guncellenecekogretmen.OgretmenAdi = Console.ReadLine();
					Console.WriteLine("Lütfen Öğretmenin Yeni Soyadını Giriniz:");
					guncellenecekogretmen.OgretmenSoyadi = Console.ReadLine();
					Console.WriteLine("Lütfen Öğretmenin Yeni E-mail Giriniz:");
					guncellenecekogretmen.OgretmenEmail = Console.ReadLine();
					Console.WriteLine("Lütfen Öğretmenin Yeni Doğum Tarihini Giriniz:");
					guncellenecekogretmen.OgretmenDogumTarihi = Convert.ToDateTime(Console.ReadLine());
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
			await GetAllAsync();
			Ogretmen Ogretmensil = new();
			Console.WriteLine("Lütfen Silmek İstediğiniz Öğretmenin NO Giriniz:");
			Ogretmensil.OgretmenID = int.Parse(Console.ReadLine());
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					context.Ogretmenler.Remove(Ogretmensil);
					await context.SaveChangesAsync();
					Console.WriteLine("Öğretmen Başarılı Bir Şekilde Silindi !");
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
					var ogretmen = await (from Ogretmen in context.Ogretmenler
										  where Ogretmen.OgretmenID == id
										  select Ogretmen).ToListAsync();
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
					var ogretmenler = await (from Ogretmen in context.Ogretmenler
											 select Ogretmen).ToListAsync();
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
					Console.WriteLine(await(from Ogretmen in context.Ogretmenler
											select Ogretmen).CountAsync());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
	}
}
