using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IExtensiveReceptionProfileRepository :IBaseRepository<ExtensiveReceptionProfile>
    {
        ObservableCollection<ExtensiveReceptionProfile> GetByAllEntityObservableCollection(string numberSpecification);
        ObservableCollection<ExtensiveReceptionProfile> GetByAllEntityObservableCollection(string numberSpecification, DateTime? date);
    }
}
