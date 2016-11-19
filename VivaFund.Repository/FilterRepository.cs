using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;
using VivaFund.Interfaces;

namespace VivaFund.Repository
{
    public class FilterRepository : IFilterRepository
    {
        private readonly ApplicationDbContext _context;

        public FilterRepository()
        {
            _context = new ApplicationDbContext();
        }

        public FilterRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Filter> GetAllFilters()
        {

            var filters = _context.Filters.ToList();

            return filters;

        }

        public IEnumerable<Filter> GetAllFiltersByType(string type)
        {
            var filters = _context.Filters.Where(u => u.FilterType == type).ToList();

            return filters;

        }

    }
}
