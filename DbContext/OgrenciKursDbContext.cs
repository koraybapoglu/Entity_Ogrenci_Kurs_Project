using Entity_Ogrenci_Kurs_Project.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entity_Ogrenci_Kurs_Project
{
	public class OgrenciKursDbContext : DbContext
	{
		public DbSet<Ogrenci> Ogrenciler { get; set; }
		public DbSet<Ogretmen> Ogretmenler { get; set; }
		public DbSet<Ders> Dersler { get; set; }
		public DbSet<Kurs> Kurslar { get; set; }
		public DbSet<OgrenciKurs> Ogrenci_Kurslar { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-RN1V6Q9;Database=DbOgrenciKurs;Trusted_Connection=True;TrustServerCertificate=true;");
		}
	}
}
