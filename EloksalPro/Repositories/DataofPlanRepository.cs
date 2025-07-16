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
    public class DataofPlanRepository:BaseRepo<DataPlanProfile>, IDataofPlanRepository
    {
        public double? GetWeight(DateTime? date)
        {
            var entity = Table.GroupBy(p=>p.DatePlan)
                .Select(g => new
                {
                    GeneralWeight=g.Sum(e=>e.GeneralWeight),
                    Date = g.Key
                }).FirstOrDefault(p => p.Date == date); ;
            if (entity != null)
            {
                return entity.GeneralWeight;
            }
            else
            {
                return 0;
            }
        }


        public List<DataPlanProfileGenaral> GetGeneralDataUpload()
        {
            List<DataPlanProfileGenaral> list = new List<DataPlanProfileGenaral>();
            list = Table.GroupBy(p=>p.DatePlan)
                .Select (g=>new DataPlanProfileGenaral
                {
                    DatePlan=g.Key,
                    GeneralWeight=g.Sum(t=>t.GeneralWeight),

                }).ToList();
            return list;
        }
    }
}
