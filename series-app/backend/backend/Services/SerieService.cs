using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public class SerieService
    {
        private readonly DataContext _context;

        public SerieService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Serie>> findAllAsync()
        {
            return await _context.Serie.AsNoTracking().ToListAsync();
        }
    }
}
