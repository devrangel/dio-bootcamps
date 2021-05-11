using backend.Data;
using backend.Models;
using backend.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public class CategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Category.AsNoTracking().ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Category.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Category model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category model)
        {
            bool hasAny = await _context.Category.AnyAsync(x => x.Id == model.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Categoria não encontrada");
            }

            try
            {
                _context.Entry<Category>(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw new DbConcurrencyException("Este registro já foi atualizado");
            }
            catch(Exception)
            {
                throw new GenericException("Não foi possível atualizar a categoria");
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Category category = await _context.Category.FirstOrDefaultAsync(x => x.Id == id);

                if(category == null)
                {
                    throw new NotFoundException("Categoria não encontrada");
                }
                else
                {
                    _context.Category.Remove(category);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception)
            {
                throw new GenericException("Não foi possível remover a categoria");
            }
        }
    }
}
