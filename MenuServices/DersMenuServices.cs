using Entity_Ogrenci_Kurs_Project.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.MenuServices
{
	internal class DersMenuServices
	{
		public async static void DersMenu()
		{
			DersServices dersservices = new();
			bool isRunning = true;
			while (isRunning)
			{
				Console.WriteLine("1-Ders Eklemek İçin,");
				Console.WriteLine("2-Ders Çıkarmak İçin,");
				Console.WriteLine("3-Ders Güncellemek İçin,");
				Console.WriteLine("4-Ders Listelemek için,");
				Console.WriteLine("5-Ders Menüsünden Çıkış Yapmak İçin Tuşlayınız.");
				switch (int.Parse(Console.ReadLine()))
				{
					case 1:
						Console.Clear();
						await dersservices.GetAllAsync();
						break;
					case 2:
						Console.Clear();
						await dersservices.GetAllAsync();
						break;
					case 3:
						Console.Clear();
						await dersservices.UpdateAsync();
						break;
					case 4:
						Console.Clear();
						await dersservices.GetAllAsync();
						break;
					case 5:
						isRunning = false;
						break;
				}
			}
		}
	}
}
