using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Ogrenci_Kurs_Project.Interfaces
{
	public interface ICrudService<T>
	{
		Task AddAsync();
		Task UpdateAsync();
		Task DeleteAsync();
		Task GetByIdAsync(int id);
		Task GetAllAsync();
		Task GetCountAsync();
	}
}
