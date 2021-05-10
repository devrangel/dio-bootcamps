using backend.Data;
using backend.Models;
using backend.Services.Exceptions;
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

        public async Task createAsync(Serie model)
        {
            _context.Serie.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Serie model)
        {
            bool hasAny = await _context.Serie.AnyAsync(x => x.Id == model.Id);
            if(!hasAny)
            {
                throw new NotFoundException("Série não encontrada");
            }

            try
            {
                _context.Entry<Serie>(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            Serie model = await _context.Serie.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                throw new NotFoundException("Série não encontrada");
            }

            try
            {
                _context.Serie.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new IntegrityException("Série não pode ser removida");
            }
        }
    }
}
