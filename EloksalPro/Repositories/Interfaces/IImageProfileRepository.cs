using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface IImageProfileRepository:IBaseRepository<ImageProfile>
    {
        ImageProfile GetByExaminationNomenclature(int id);
        void RemoveImage(int id);
    }
}
