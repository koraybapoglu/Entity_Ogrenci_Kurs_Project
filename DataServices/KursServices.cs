using Entity_Ogrenci_Kurs_Project.Entities;
using Entity_Ogrenci_Kurs_Project.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Entity_Ogrenci_Kurs_Project.DataServices
{
	public class KursServices : ICrudService<Kurs>
	{
		OgretmenServices ogrservis = new();
		public async Task AddAsync()
		{
			try
			{
				Kurs eklenecekkurs = new();
				Console.WriteLine("Lütfen Eklemek İstediğiniz Kursun Adını Giriniz:");
				eklenecekkurs.KursAdi = Console.ReadLine();
				Console.WriteLine();
				await ogrservis.GetAllAsync();
				Console.WriteLine("Lütfen Kursun Öğretmeninin NO Giriniz:");
				eklenecekkurs.OgretmenID = Convert.ToInt32(Console.ReadLine());
				using (var context = new OgrenciKursDbContext())
				{
					await context.Kurslar.AddAsync(eklenecekkurs);
					await context.SaveChangesAsync();
				}
				Console.WriteLine("Kurs Başarıyla Eklendi !");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}

		public async Task DeleteAsync()
		{
			try
			{
				await GetAllAsync();
				Kurs silinecekkurs = new();
				Console.WriteLine("Lütfen Silinecek Olan Kursun ID'sini Giriniz:");
				silinecekkurs.KursID = Convert.ToInt32(Console.ReadLine());
				using (var context = new OgrenciKursDbContext())
				{
					context.Kurslar.Remove(silinecekkurs);
					await context.SaveChangesAsync();
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
					var kurslargetir = await context.Kurslar.Join
							 (context.Ogretmenler,
							 D => D.OgretmenID,
							 O => O.OgretmenID,
							 (D, O) => new
							 {
								 KursID = D.KursID,
								 KursAdi = D.KursAdi,
								 KursBaslangicTarihi = D.BaslangicTarihi,
								 KursBitisTarihi = D.BitisTarihi,
								 OgretmenAdi = O.OgretmenAdi,
								 OgretmenSoyadi = O.OgretmenSoyadi,

							 }).ToListAsync();
					foreach (var item in kurslargetir)
					{
						Console.WriteLine($"-----------------------------------------------------\n" +
							$"Kurs NO: {item.KursID}\n" +
							$"Kurs Adı: {item.KursAdi}\n" +
							$"Kurs Başlangıç Tarihi : {item.KursBaslangicTarihi}\n" +
							$"Kurs Bitiş Tarihi: {item.KursBitisTarihi}\n" +
							$"Öğretmen Adı: {item.OgretmenAdi}\n" +
							$"Öğretmen Soyadı: {item.OgretmenSoyadi}\n" +
							$"-----------------------------------------------------\n");
					}
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
					var kurs = await (from Kurs in context.Kurslar
									  where Kurs.KursID == id
									  join Ogretmen in context.Ogretmenler on Kurs.OgretmenID equals Ogretmen.OgretmenID
									  select new
									  {
										  Kurs.KursID,
										  Kurs.KursAdi,
										  Kurs.BaslangicTarihi,
										  Kurs.BitisTarihi,
										  Ogretmen.OgretmenAdi,
										  Ogretmen.OgretmenSoyadi
									  }).ToListAsync();
					foreach (var item in kurs)
					{
						Console.WriteLine("--------------------------------------------\n" +
										  $"Kurs NO: {item.KursID}\n" +
										  $"Kurs Adı: {item.KursAdi}\n" +
										  $"Kurs Başlangıç Tarihi: {item.BaslangicTarihi}\n" +
										  $"Kurs Bitiş Tarihi: {item.BitisTarihi}\n" +
										  $"Kurs Öğretmeni Adı: {item.OgretmenAdi}\n" +
										  $"Kurs Öğretmeni Soyadı: {item.OgretmenSoyadi}\n" +
										  "--------------------------------------------\n");
					}
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
				await GetAllAsync();
				Kurs guncellenecekkurs = new();
				Console.WriteLine("Lütfen Güncellenecek Olan Kursun NO Giriniz:");
				guncellenecekkurs.KursID = int.Parse(Console.ReadLine());
				Console.WriteLine("Lütfen Kursun Yeni Adını Giriniz:");
				guncellenecekkurs.KursAdi = Console.ReadLine();
				Console.WriteLine("Lütfen Kursun Yeni Acilis Tarihini Giriniz:");
				guncellenecekkurs.BaslangicTarihi = Convert.ToDateTime(Console.ReadLine());
				Console.WriteLine("Lütfen Kursun Yeni Bitiş Tarihini Giriniz:");
				guncellenecekkurs.BitisTarihi = Convert.ToDateTime(Console.ReadLine());
				await ogrservis.GetAllAsync();
				Console.WriteLine("Lütfen Yeni Öğretmenin NO Giriniz:");
				guncellenecekkurs.OgretmenID = int.Parse(Console.ReadLine());
				using (var context = new OgrenciKursDbContext())
				{
					await context.SaveChangesAsync();
					Console.WriteLine("Başarılı Bir Şekilde Güncelleme Tamamlandı !");
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task KursKayitOlmayanOgrenci()
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					var butunOgrenciKurslar = context.Ogrenci_Kurslar; // Ogrenci_Kurslar tablosunu alıyoruz.

					var butunOgrenciIDler = butunOgrenciKurslar.Select(ok => ok.OgrenciID).ToList(); // Tüm OgrenciID'leri alıyoruz.
					var butunKursIDler = butunOgrenciKurslar.Select(ok => ok.KursID).ToList(); // Tüm KursID'leri alıyoruz.

					var tumOgrenciler = context.Ogrenciler.Select(o => o.OgrenciID).ToList(); // Tüm öğrenci ID'lerini alıyoruz.
					var tumKurslar = context.Kurslar.Select(k => k.KursID).ToList(); // Tüm kurs ID'lerini alıyoruz.

					var eksikOgrenciler = tumOgrenciler.Except(butunOgrenciIDler).ToList(); // Eksik öğrenci ID'lerini buluyoruz.
					var eksikKurslar = tumKurslar.Except(butunKursIDler).ToList(); // Eksik kurs ID'lerini buluyoruz.

					if (eksikOgrenciler != null)
					{
						foreach (var item in eksikOgrenciler)
						{
							Console.WriteLine("Eksik Öğrenciler:" + item);
						}
					}
					else
					{
						Console.WriteLine("Eksik Öğrenci bulunmamaktadır.");
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
					Console.WriteLine(await (from ogrenci in context.Ogrenciler
											 select ogrenci).CountAsync());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task OgrencileriKursAdinaGoreGetir(string kursAdi)
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					var kurs = context.Kurslar.FirstOrDefault(k => k.KursAdi == kursAdi);

					if (kurs != null)
					{
						var kursaKayitliOgrenciler = await (from kayit in context.Ogrenci_Kurslar
															join ogrenci in context.Ogrenciler
															on kayit.OgrenciID equals ogrenci.OgrenciID
															where kayit.KursID == kurs.KursID
															select ogrenci).ToListAsync();

						Console.WriteLine($"Kurs Adı: {kurs.KursAdi}");
						Console.WriteLine("Kursa Kayıtlı Öğrenciler:");

						foreach (var ogrenci in kursaKayitliOgrenciler)
						{
							Console.WriteLine($"Öğrenci Adı: {ogrenci.OgrenciAdi}, Öğrenci Soyadı: {ogrenci.OgrenciSoyadi}");
						}
					}
					else
					{
						Console.WriteLine($"'{kursAdi}' adlı kurs bulunamadı.");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task GetMinKursAsync()
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					int minKursID = await context.Ogrenci_Kurslar.MinAsync(ok => ok.KursID);

					Console.WriteLine($"Minimum Kurs ID: {minKursID}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task GetMaxKursAsync()
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					int maxKursID = await context.Ogrenci_Kurslar.MaxAsync(ok => ok.KursID);

					Console.WriteLine($"Maksimum Kurs ID: {maxKursID}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}



	}
}
