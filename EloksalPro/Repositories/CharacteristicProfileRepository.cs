using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EloksalPro.Repositories
{
   public  class CharacteristicProfileRepository:BaseRepo<СharacteristicProfile>, IСharacteristicProfileRepository
    {
        public void ProfilePropertiesUpdate(int Id, string Name,string Marking,string Description)
        {
            var myEntity = Table.FirstOrDefault(e => e.Id == Id);
            if (myEntity != null)
            {
                myEntity.ProfilePropertyName = Name;
                myEntity.ProfilePropertyMarking= Marking;
                myEntity.ProfilePropertyDescription = Description;
                Context.SaveChanges();
                MessageBox.Show("Данные успешно изменены");
            }
        }
        public List<СharacteristicProfile> GetByAllEntityType()
        {
            List<СharacteristicProfile> list = new List<СharacteristicProfile>();
            list = Table.Where(p => p.ProfilePropertyName.StartsWith("Вид")).ToList();
            return list;
        }
        public List<СharacteristicProfile> GetByAllEntityColor()
        {
            List<СharacteristicProfile> list = new List<СharacteristicProfile>();
            list = Table.Where(p => p.ProfilePropertyName.StartsWith("Цвет")).ToList();
            return list;
        }
        public List<СharacteristicProfile> GetByAllEntityAdditional()
        {
            List<СharacteristicProfile> list = new List<СharacteristicProfile>();
            list = Table.Where(p => p.ProfilePropertyName.StartsWith("Дополнительные")).ToList();
            return list;
        }
        public List<String> GetByAllListType()
        {
            List<String> list = new List<String>();
            list = Table.Where(p => p.ProfilePropertyName.StartsWith("Вид")).Select(p=>p.ProfilePropertyMarking).ToList();
            return list;
        }
        public List<String> GetByAllListColor()
        {
            List<String> list = new List<String>();
            list = Table.Where(p => p.ProfilePropertyName.StartsWith("Цвет")).Select(p => p.ProfilePropertyMarking).ToList();
            return list;
        }
    }
}
