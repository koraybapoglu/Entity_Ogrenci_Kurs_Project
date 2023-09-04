using Entity_Ogrenci_Kurs_Project.DataServices;
using Entity_Ogrenci_Kurs_Project.MenuServices;

namespace Entity_Ogrenci_Kurs_Project
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool isRunning = true;
			while (isRunning) 
			{
				Console.Clear();
                Console.WriteLine("1-Öğrenci İşlemleri İçin,");
                Console.WriteLine("2-Öğretmen İşlemleri İçin,");
                Console.WriteLine("3-Ders İşlemleri İçin,");
                Console.WriteLine("4-Kurs İşlemleri İçin,");
                Console.WriteLine("5-Admin Giriş İçin,");
				Console.WriteLine("6-Çıkış Yapmak İçin Tuşlayınız.");
				switch (Convert.ToInt32(Console.ReadLine()))
				{
					case 1:
						OgrenciMenuServices.OgrenciMenu();
						break;
					case 2:
						OgretmenMenuServices.OgretmenMenu();
						break;
					case 3:
					
						break;
					case 4:
						
						break;
					case 5:
						break;
					case 6:
						isRunning = false;
						break;
				}
			}
		}
	}
}