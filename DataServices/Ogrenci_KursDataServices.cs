using Entity_Ogrenci_Kurs_Project.Entities;
using Entity_Ogrenci_Kurs_Project.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.DataServices
{
	public class Ogrenci_KursDataServices : IOgrenci_KursService
	{
		OgrenciServices ogrenciservice = new();
		KursServices kursServices = new();
		public async Task OgrenciKursGuncelle()
		{
			try
			{
				await this.OgrenciKursGetir();
				await ogrenciservice.GetAllAsync();
				OgrenciKurs ogrkursguncelle = new();
				Console.WriteLine("Güncellemek istediğiniz Kursun NO Giriniz:");
				ogrkursguncelle.OgrenciKursID = int.Parse(Console.ReadLine());
				Console.Clear();
				await ogrenciservice.GetAllAsync();
				Console.WriteLine("Yeni Öğrenci NO Giriniz:");
				ogrkursguncelle.OgrenciID = int.Parse(Console.ReadLine());
				Console.Clear();
				await kursServices.GetAllAsync();
				Console.WriteLine("Yeni Kurs No Giriniz:");
				ogrkursguncelle.KursID = int.Parse(Console.ReadLine());
				using (var context = new OgrenciKursDbContext())
				{
					await context.SaveChangesAsync();
				}
				Console.Clear();
				Console.WriteLine("Başarılı Bir Şekilde Güncelleme Tamamlanmıştır.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}

		}

		public async Task OgrenciKursKayit()
		{
			try
			{
				await ogrenciservice.GetAllAsync();
				OgrenciKurs ogrkursekle = new();
				Console.WriteLine("Lütfen Öğrenci NO Giriniz:");
				ogrkursekle.OgrenciID = int.Parse(Console.ReadLine());
				Console.Clear();
				await kursServices.GetAllAsync();
				Console.WriteLine("Lütfen Kurs NO Giriniz:");
				Console.Clear();
				ogrkursekle.KursID = int.Parse(Console.ReadLine());
				using (var context = new OgrenciKursDbContext())
				{
					await context.Ogrenci_Kurslar.AddAsync(ogrkursekle);
					await context.SaveChangesAsync();
				}
				Console.Clear();
				Console.WriteLine("Başarılı Bir Şekilde Öğrenci Kursa Yerleştirildi !");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}

		public async Task OgrenciKursSil()
		{
			try
			{
				await this.OgrenciKursGetir();
				OgrenciKurs ogrkurssil = new();
				Console.WriteLine("Lütfen Silinecek Olan Kurs ve Öğrenciye Ait olan Öğrenci_Kurs NO Giriniz:");
				ogrkurssil.OgrenciKursID = int.Parse(Console.ReadLine());
				using (var context = new OgrenciKursDbContext())
				{
					context.Ogrenci_Kurslar.Remove(ogrkurssil);
					await context.SaveChangesAsync();
				}
				Console.Clear();
				Console.WriteLine("Başarılı Bir Şekilde Kurs Veritabanından Silindi !");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task OgrenciKursGetir()
		{
			try
			{
				using (var context = new OgrenciKursDbContext())
				{
					var ogrkurs = await (from OgrenciKurs in context.Ogrenci_Kurslar
										 select OgrenciKurs).ToListAsync();
					if (ogrkurs != null)
					{
						foreach (var item in ogrkurs)
						{
							Console.WriteLine("Öğrenci_Kurs NO:" + item.OgrenciKursID);
							Console.WriteLine("Öğrenci NO:" + item.OgrenciID);
							Console.WriteLine("Kurs NO:" + item.KursID);
						}
					}
					else
					{
						Console.WriteLine("Kayıt Bulunamadı !");
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
