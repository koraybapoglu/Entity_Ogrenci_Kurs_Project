using Entity_Ogrenci_Kurs_Project.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.MenuServices
{
	public class OgretmenMenuServices
	{
		public static void OgretmenMenu()
		{
			OgretmenServices ogretservices = new();
			bool isRunning = true;
			while (isRunning)
			{
				Console.WriteLine("1-Öğretmen Eklemek İçin,");
				Console.WriteLine("2-Öğretmen Çıkarmak İçin,");
				Console.WriteLine("3-Öğretmen Güncellemek İçin,");
				Console.WriteLine("4-Öğretmen Listelemek için,");
				Console.WriteLine("5-Öğretmen Menüsünden Çıkış Yapmak İçin Tuşlayınız.");
				switch (int.Parse(Console.ReadLine()))
				{
					case 1:
						ogretservices.OgretmenEkle();
						break;
					case 2:
						ogretservices.OgretmenSil();
						break;
					case 3:
						ogretservices.OgretmenGuncelle();
						break;
					case 4:
						ogretservices.OgretmenleriGetir();
						break;
					case 5:
						isRunning = false;
						break;
				}
			}
		}
	}
}
