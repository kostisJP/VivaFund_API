using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.ServicesInterfaces
{
    public interface IFilterService 
    {
        IEnumerable<Filter> GetFilterByType(string type);

        IEnumerable<Filter> GetAllFilters();
    }
}
