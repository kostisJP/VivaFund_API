using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;
using VivaFund.ServicesInterfaces;

namespace VivaFund.Services
{
    public class FilterService : IFilterService
    {
        private readonly IFilterRepository _filterRepo;
        public FilterService(IFilterRepository filterRepo)
        {
            _filterRepo = filterRepo;
        }

        public IEnumerable<Filter> GetAllFilters()
        {
            IEnumerable<Filter> filters = _filterRepo.GetAllFilters();
            return filters;
        }

        public IEnumerable<Filter> GetFilterByType(string type)
        {
            IEnumerable<Filter> filters = _filterRepo.GetAllFiltersByType(type);
            return filters;
        }
    }
}
