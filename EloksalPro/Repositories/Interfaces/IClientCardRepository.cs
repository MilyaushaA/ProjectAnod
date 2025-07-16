using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface IClientCardRepository : IBaseRepository<ClientCard>
    {
        void ClientCardUpdate(int id, string ClientNo, string ClientName, DateTime? date, string PhysicalAddress,
                                  string ContactPerson, string ContactNumberPhone, string ContactEmail,string Manager);
        List<string> GetByExaminationNomenclature();
    }
}
