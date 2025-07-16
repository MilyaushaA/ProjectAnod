using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EloksalPro.Repositories
{
    public class ImageProfileRepository:BaseRepo<ImageProfile>, IImageProfileRepository
    {
        public ImageProfile GetByExaminationNomenclature(int id)
        {

            ImageProfile list = Table.FirstOrDefault(p => p.ClientId == id);
            if (list!=null)
            return list;
            else
            {
                return null;
            }
        }
        public void RemoveImage(int id)
        {
            ImageProfile list = Table.FirstOrDefault(x => x.ClientId == id);
            if (list != null)
            {
                Table.Remove(list);
                Context.SaveChanges();
            }      
        }
       public override void Add(ImageProfile entity)
        {
            try
            {
                Table.Add(entity);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Произошла ошибка при добавление данных", ex);
            }
        }

        public void UpdateImage(int id, byte[] image)
        {
            ImageProfile list = Table.FirstOrDefault(x => x.ClientId == id);
            if (list != null)
            {
                list.ImageBytes = image;
                Context.SaveChanges();
            }
        }
    }
}
