using Application.Core.Entities;
using Application.Core.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Infrastructure.Data
{
    public class PersonalAccountRepository : IPersonalAccountRepository
    {
        private readonly AccountContext accountContext;

        public PersonalAccountRepository(AccountContext accountContext)
        {
            this.accountContext = accountContext;
        }

        public async Task AddAsync(double amount, string description)
        {
            await accountContext.PersonalAccount.AddAsync(new PersonalAccount { Sum = amount, Description = description});
            await accountContext.SaveChangesAsync();
        }

        public async Task<double> GetAll()
        {
            return await accountContext.PersonalAccount.SumAsync(x => x.Sum);
        }
        public async Task<double> GetAllByDescription(string description)
        {
            var amounts = await accountContext.PersonalAccount.Where(x => x.Description == description).Select(x => x.Sum).ToListAsync();
            return await accountContext.PersonalAccount.SumAsync(x => x.Sum);
        }
        public async Task<double> GetAllAdded()
        {
            var addedSum = await accountContext.PersonalAccount.Where(x => x.Sum > 0).Select(x => x.Sum).ToListAsync();

            return addedSum.Sum();
        }


        public async Task<double> GetAllSubtract()
        {
            var addedSum = await accountContext.PersonalAccount.Where(x => x.Sum < 0).Select(x => x.Sum).ToListAsync();

            return addedSum.Sum();
        }

    }
}
