using backend.Data;
using backend.Models;
using backend.Models.ViewModels;
using backend.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public class AccountService
    {
        private readonly DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> findAllAsync()
        {
            return await _context.Account.AsNoTracking().ToListAsync();
        }

        public async Task<Account> findByIdAsync(int id)
        {
            return await _context.Account.AsNoTracking().FirstOrDefaultAsync(account => account.Id == id);
        }

        public async Task SacarAsync(int id, AccountViewModel viewModel)
        {
            bool hasAny = await _context.Account.AnyAsync(x => x.Id == id);

            if (!hasAny)
            {
                throw new NotFoundException("Conta não encontrada");
            }

            viewModel.Account.Sacar(viewModel.Valor);

            try
            {
                _context.Entry<Account>(viewModel.Account).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbConcurrencyException("Este registro já foi atualizado");
            }
        }

        public async Task DepositarAsync(int id, AccountViewModel viewModel)
        {
            bool hasAny = await _context.Account.AnyAsync(x => x.Id == id);

            if (!hasAny)
            {
                throw new NotFoundException("Conta não encontrada");
            }

            viewModel.Account.Depositar(viewModel.Valor);

            try
            {
                _context.Entry<Account>(viewModel.Account).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbConcurrencyException("Este registro já foi atualizado");
            }
        }

        public async Task TransferirAsync(int id, AccountViewModel viewModel)
        {
            bool hasAnyFrom = await _context.Account.AnyAsync(x => x.Id == id);
            bool hasAnyTo = await _context.Account.AnyAsync(x => x.Id == viewModel.SendToAccount);

            if (!hasAnyFrom)
            {
                throw new NotFoundException("Conta remetente não encontrada");
            }

            if (!hasAnyTo)
            {
                throw new NotFoundException("Conta destinatária não encontrada");
            }

            viewModel.ToAccount = await findByIdAsync(viewModel.SendToAccount);

            viewModel.Account.Transferir(viewModel.Valor, viewModel.ToAccount);

            try
            {
                _context.Entry<Account>(viewModel.Account).State = EntityState.Modified;
                _context.Entry<Account>(viewModel.ToAccount).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbConcurrencyException("Este registro já foi atualizado");
            }
        }

        public async Task EditarAsync(int id, AccountViewModel viewModel)
        {
            bool hasAny = await _context.Account.AnyAsync(x => x.Id == id);

            if (!hasAny)
            {
                throw new NotFoundException("Conta não encontrada");
            }

            viewModel.Account.Nome = viewModel.UpdatedNome;
            viewModel.Account.TipoConta = viewModel.UpdatedTipoConta;

            try
            {
                _context.Entry<Account>(viewModel.Account).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbConcurrencyException("Este registro já foi atualizado");
            }
        }
    }
}
