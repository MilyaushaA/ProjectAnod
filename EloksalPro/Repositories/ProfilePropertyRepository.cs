using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
    public class ProfilePropertyRepository : BaseRepo<ProfileProperty>, IProfilePropertyRepository
    {
        public List<string> PropertyLenghtProfile()
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.PropertyProfile.StartsWith("Длина")).Select(p => p.ValuePropertyProfile).ToList();
            return list;


            //List<int> list = new List<int>();
            //list = Table.Where(p => p.PropertyProfile.StartsWith("Длина"))
            //           .Select(p => Int32.Parse(p.ValuePropertyProfile))   // Конвертируем строки в числа
            //           .OrderBy(p => p)                                    // Сортируем по числам
            //           .ToList();                                          // Получаем список чисел

            //return list;
        }

        public List<string> PropertyTypeProfile()
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.PropertyProfile.StartsWith("Вид")).Select(p => p.ValuePropertyProfile).ToList();
            return list;
        }
        public List<string> PropertyColorProfile()
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.PropertyProfile.StartsWith("Цвет")).Select(p => p.ValuePropertyProfile).ToList();
            return list;
        }
        public List<string> PropertyThicknessProfile(string name)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.PropertyProfile.StartsWith(name)).Select(p => p.ValuePropertyProfile).ToList();
            return list;
        }
      
        public List<string> GetByExaminationPropertyProfile()
        {
            List<string> list = new List<string>();
            list = Table.Select(p => p.PropertyProfile+":"+p.ValuePropertyProfile).ToList();
            return list;
        }
    }
}
