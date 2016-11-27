using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.Interfaces
{
    public interface IFilterRepository
    {
        IEnumerable<Filter> GetAllFilters();
        IEnumerable<Filter> GetAllFiltersByType(string type);
    }
}
