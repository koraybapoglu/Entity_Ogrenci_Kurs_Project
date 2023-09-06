using Entity_Ogrenci_Kurs_Project.DataServices;
using Entity_Ogrenci_Kurs_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.MenuServices
{
	public class AdminMenuServices
	{
		AdminDataServices adminData = new();
		public async void AdminMenuGiris()
		{
			try
			{
				Admin admingiris = new();
				Console.WriteLine("Lütfen Kullanıcı Adınızı Giriniz:");
				admingiris.AdminK_Adi = Console.ReadLine();
				Console.WriteLine("Lütfen Şifrenizi Giriniz:");
				admingiris.AdminSifre = Console.ReadLine();
				using (var context = new OgrenciKursDbContext())
				{
					bool girisonay = Convert.ToBoolean(await context.Admins.FindAsync(admingiris));
					if (girisonay == true)
					{
						Console.Clear();
						Console.WriteLine("Hoşgeldiniz !");
						AdminGirisOnay();
					}
					else
					{
						Console.WriteLine("Hatalı Giriş Yaptınız Lütfen Tekrar Deneyiniz.");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Hata Oluştu: " + ex.Message);
			}
		}
		public async Task AdminGirisOnay()
		{
			bool isTrue = true;
			while (isTrue==true)
			{
				try
				{
					Console.WriteLine(@"------------------------------
                                    1-Öğrencileri Getir,
                                    2-Öğrenci Getir,
                                    3-Öğrenci Sayısı Getir,
                                    4-Öğrencileri Kursa Göre Getir,
                                    5-Öğrenci Kurs Kayıt,
                                    6-Öğrenci Kurs Sil,
                                    7-Öğrenci Kurs Güncelle,
                                    ------------------------------
                                    8-Öğretmenleri Getir,
                                    9-Öğretmen Getir,
                                    10-Öğretmen Sayısı Getir,
                                    ------------------------------
                                    11-Dersleri Getir,
                                    12-Ders Getir,
                                    13-Ders Sayısı Getir,
                                    ------------------------------
                                    14-Kursları Getir,
                                    15-Kurs Getir,
                                    16-Kurs Sayısı Getir,
                                    17-En Çok Kayıt Olunan Kurs Getir,
                                    18-En Az Kayıt Olunan Kurs Getir,
                                    19-Kursa Kayıt Olan Öğrencileri Kursa Göre Getir,
                                    20-Kursa Hiç Kaydı Olmayan Öğrencileri Getirmek için Tuşlayınız.
                                    ------------------------------");
					switch (int.Parse(Console.ReadLine()))
					{
						case 1:
							await adminData.OgrencilerGetir();
							break;
						case 2:
							await adminData.OgrencilerGetir();
							Console.WriteLine();
							Console.WriteLine();
                            await adminData.OgrenciGetir();
							break;
						case 3:
							await adminData.OgrenciSayisiGetir();
							break;
						case 4:
							await adminData.OgrenciGruplariGetir();
							break;
						case 5:
							await adminData.OgrenciKursKayit();
							break;
						case 6:
							await adminData.OgrenciKursSil();
							break;
						case 7:
							await adminData.OgrenciKursGuncelle();
							break;
						case 8:
							await adminData.OgretmenleriGetir();
							break;
						case 9:
							await adminData.OgretmenleriGetir();
							Console.WriteLine();
							Console.WriteLine();
							await adminData.OgretmenGetir();
							break;
						case 10:
							await adminData.OgretmenSayiGetir();
							break;
						case 11:
							await adminData.DersleriGetir();
							break;
						case 12:
							await adminData.DersleriGetir();
							Console.WriteLine();
							Console.WriteLine();
							await adminData.DersGetir();
							break;
						case 13:
							await adminData.DersSayiGetir();
							break;
						case 14:
							await adminData.KurslariGetir();
							break;
						case 15:
							await adminData.KurslariGetir();
							Console.WriteLine();
							Console.WriteLine();
							await adminData.KursGetir();
							break;
						case 16:
							await adminData.KursSayiGetir();
							break;
						case 17:
							await adminData.MaxKursGetir();
							break;
						case 18:
							await adminData.MınKursGetir();
							break;
						case 19:
							await adminData.KursGruplariGetir();
							break;
						case 20:
							await adminData.KursaKayıtOlmayanOgrenci();
							break;
						default:
							Console.WriteLine("Hatalı Tuşlama Lütfen Tekrar Deneyiniz.");
							break;
					}

				}
				catch (Exception ex)
				{

					Console.WriteLine("Hata Oluştu: " + ex.Message);
				}
			}
			
		}
	}
}
