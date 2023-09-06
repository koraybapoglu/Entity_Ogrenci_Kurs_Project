using Entity_Ogrenci_Kurs_Project.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.MenuServices
{
	public class KursMenuServices
	{
		public async static void KursMenu()
		{
			KursServices kursServices = new();
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
						await kursServices.AddAsync();
						break;
					case 2:
						await kursServices.DeleteAsync();
						break;
					case 3:
						await kursServices.UpdateAsync();
						break;
					case 4:
						await kursServices.GetAllAsync();
						break;
					case 5:
						isRunning = false;
						break;
				}
			}
		}
	}
}
