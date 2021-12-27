using Application.Core.Entities;
using Application.Core.Interfaces;
using Application.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Services
{
    public class SaveAccountRepository : ISaveAccountRepository
    {
        private readonly AccountContext accountContext;

        public SaveAccountRepository(AccountContext accountContext)
        {
            this.accountContext = accountContext;
        }

        public async Task AddAsync(double amount, string description)
        {
            await accountContext.SaveAccount.AddAsync(new SaveAccount { Sum = amount, Description = description });
            await accountContext.SaveChangesAsync();
        }

        public async Task<double> GetAll()
        {
            return await accountContext.SaveAccount.SumAsync(x => x.Sum);
        }

        public async Task<double> GetAllAdded()
        {
            var addedSum = await accountContext.SaveAccount.Where(x => x.Sum > 0).Select(x => x.Sum).ToListAsync();

            return addedSum.Sum();
        }

        public async Task<double> GetAllByDescription(string description)
        {
            var amounts = await accountContext.SaveAccount.Where(x => x.Description == description).Select(x => x.Sum).ToListAsync();
            return await accountContext.SaveAccount.SumAsync(x => x.Sum);
        }

        public async Task<double> GetAllSubtract()
        {
            var addedSum = await accountContext.SaveAccount.Where(x => x.Sum < 0).Select(x => x.Sum).ToListAsync();

            return addedSum.Sum();
        }
    }
}
