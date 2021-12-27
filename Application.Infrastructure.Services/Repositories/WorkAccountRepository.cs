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
    public class WorkAccountRepository : IWorkAccountRepository
    {
        private readonly AccountContext accountContext;

        public WorkAccountRepository(AccountContext accountContext)
        {
            this.accountContext = accountContext;
        }

        public async Task AddAsync(double amount, string description)
        {
            await accountContext.WorkAccount.AddAsync(new WorkAccount { Sum = amount, Description = description });
            await accountContext.SaveChangesAsync();
        }
        public async Task<double> GetAll()
        {
            return await accountContext.WorkAccount.SumAsync(x => x.Sum);
        }
        public async Task<double> GetAllByDescription(string description)
        {
            var amounts = await accountContext.WorkAccount.Where(x => x.Description == description).Select(x => x.Sum).ToListAsync();
            return await accountContext.WorkAccount.SumAsync(x => x.Sum);
        }

        public async Task<double> GetAllAdded()
        {
            var addedSum = await accountContext.WorkAccount.Where(x => x.Sum > 0).Select(x => x.Sum).ToListAsync();

            return addedSum.Sum();
        }

        public async Task<double> GetAllSubtract()
        {
            var addedSum = await accountContext.WorkAccount.Where(x => x.Sum < 0).Select(x => x.Sum).ToListAsync();

            return addedSum.Sum();
        }

    }
}
