using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
    public class ProfileConsumptionWarehouseRepository : BaseRepo<ProfileConsumptionWarehouse>, IProfileConsumptionWarehouseRepository
    {
        public int MaxNumberProfileConsumptionWarehouse()
        {
            List<ProfileConsumptionWarehouse> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                List<string> numberList = list.Select(p => p.NumberProfileConsumptionWarehouse).ToList();
                List<int> eloksalNoListInt = new List<int>();

                foreach (string item in numberList)
                {
                    int number = int.Parse(item.Substring(0,3));
                    eloksalNoListInt.Add(number);
                }
                int eloksalNoIntMax = eloksalNoListInt.Max();
                return eloksalNoIntMax;
            }
            else
            {
                return 0;
            }

        }

        public ObservableCollection<ProfileConsumptionWarehouse> GetAllEntity(string anodizingProcess)
        {
            ObservableCollection<ProfileConsumptionWarehouse> list = new ObservableCollection<ProfileConsumptionWarehouse>();
            var inventory = Table.Where(x => x.NumberProfileConsumptionWarehouse.TrimEnd() == anodizingProcess.TrimEnd());
            list = new ObservableCollection<ProfileConsumptionWarehouse>(inventory);
            return list;
        }
        public List<ProfileConsumptionWarehouse> GetListAllEntity(string anodizingProcess)
        {
            List<ProfileConsumptionWarehouse> list = new List<ProfileConsumptionWarehouse> ();
            var inventory = Table.Where(x => x.NumberProfileConsumptionWarehouse.TrimEnd() == anodizingProcess.TrimEnd());
            list = new List<ProfileConsumptionWarehouse> (inventory);
            return list;
        }
        public int? GetCountNomenclature(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int? count = 0;
            if (list.Any())
            {
                count = list.Sum(x => x.QuantityProducedProfile);
            }
            return count;
        }
        public int? GetCountNomenclatureDefective(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int? count = 0;
            if (list.Any())
            {
                count = list.Sum(x => x.QuantityDefectedProfile);
            }
            return count;
        }
        public List<ForPivotTableProfileConsumptionWarehouse> GetForPivotTableProfileConsumptionWarehouse()
        {
            List<ForPivotTableProfileConsumptionWarehouse> list = new List<ForPivotTableProfileConsumptionWarehouse>();
            list = Table.GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile })
                    .Select(g => new ForPivotTableProfileConsumptionWarehouse
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        NomenclatureProfile = g.Key.NomenclatureProfile,
                        AmountPieceProfileConsumptionWarehouse = g.Sum(p => p.QuantityProducedProfile),
                        WeightProfileConsumptionWarehouse = g.Sum(p => p.WeightProducedProfile),
                        LenghtProfileConsumptionWarehouse = g.Sum(p => p.LenghtProfile * g.Sum(f => f.QuantityProducedProfile)) / 1000,
                        AmountPieceProfileConsumptionWarehouseBrak = g.Sum(p => p.QuantityDefectedProfile),
                        LenghtProfileConsumptionWarehouseBrak = g.Sum(p => p.LenghtProfile * g.Sum(f => f.QuantityDefectedProfile)) / 1000,
                        WeightProfileConsumptionWarehouseBrak = g.Sum(p => p.WeightDefectedProfile)
                    }).ToList();
            return list;
        }
        public List<String> GetListBasketNumber()
        {
            List<String> list = new List<String>();
            var inventory = Table.Select(p=>p.BasketNumber).ToList();
            list = new List<String>(inventory);
            return list;
        }
    }
}