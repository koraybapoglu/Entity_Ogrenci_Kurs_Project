using Entity_Ogrenci_Kurs_Project.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.MenuServices
{
	public class OgrenciMenuServices
	{
		public static void OgrenciMenu()
		{
			OgrenciServices ogrservices = new();
			bool isRunning = true;
			while (isRunning)
			{
				Console.WriteLine("1-Öğrenci Eklemek İçin,");
				Console.WriteLine("2-Öğrenci Çıkarmak İçin,");
				Console.WriteLine("3-Öğrenci Güncellemek İçin,");
				Console.WriteLine("4-Öğrencileri Listelemek için,");
				Console.WriteLine("5-Öğrenci Menüsünden Çıkış Yapmak İçin Tuşlayınız.");
				switch (int.Parse(Console.ReadLine()))
				{
					case 1:
						ogrservices.OgrenciEkle();
						break;
					case 2:
						ogrservices.OgrenciSil();
						break;
					case 3:
						ogrservices.OgrenciGuncelle();
						break;
					case 4:
						ogrservices.OgrencileriGetir();
						break;
					case 5:
						isRunning = false;
						break;
				}
			}
		}
	}
}
