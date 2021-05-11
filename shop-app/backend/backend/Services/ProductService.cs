using backend.Data;
using backend.Models;
using backend.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.Include(x => x.Category).AsNoTracking().ToListAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Product.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> FindByCategoryAsync(int id)
        {
            return await _context
                        .Product
                        .Include(x => x.Category)
                        .AsNoTracking()
                        .Where(x => x.CategoryId == id).ToListAsync();
        }

        public async Task CreateAsync(Product model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product model)
        {
            bool hasAny = await _context.Product.AnyAsync(x => x.Id == model.Id);
            if(!hasAny)
            {
                throw new NotFoundException("Produto não encontrado");
            }

            try
            {
                _context.Entry<Product>(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw new DbConcurrencyException("Este registro já foi atualizado");
            }
            catch(Exception)
            {
                throw new GenericException("Não foi possível atualizar o produto");
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == id);

                if (product == null)
                {
                    throw new NotFoundException("Produto não encontrado");
                }
                else
                {
                    _context.Product.Remove(product);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception)
            {
                throw new GenericException("Não foi possível remover o produto");
            }
        }
    }
}
