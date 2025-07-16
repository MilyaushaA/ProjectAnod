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
   public class ExtensiveReceptionProfileRepository : BaseRepo<ExtensiveReceptionProfile>, IExtensiveReceptionProfileRepository
    {
        public ObservableCollection<ExtensiveReceptionProfile> GetByAllEntityObservableCollection(string numberSpecification)
        {
            ObservableCollection<ExtensiveReceptionProfile> list = new ObservableCollection<ExtensiveReceptionProfile>();
            var inventory = Table.Where(p => p.NumberSpecification == numberSpecification.TrimEnd()).ToList();
            list = new ObservableCollection<ExtensiveReceptionProfile>(inventory);
            return list;
        }
        public ObservableCollection<ExtensiveReceptionProfile> GetByAllEntityObservableCollection(string numberSpecification, DateTime? date)
        {
            ObservableCollection<ExtensiveReceptionProfile> list = new ObservableCollection<ExtensiveReceptionProfile>();
            var inventory = Table.Where(p => p.NumberSpecification == numberSpecification.TrimEnd() && p.Date == date).ToList();
            list = new ObservableCollection<ExtensiveReceptionProfile>(inventory);
            return list;
        }
    }
}
