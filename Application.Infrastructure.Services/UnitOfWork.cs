using Application.Core.Entities;
using Application.Core.Interfaces;
using Application.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AccountContext accountContext;
        private IPersonalAccountRepository personalAccountRepository;
        private ISaveAccountRepository saveAccountRepository;
        private IWorkAccountRepository workAccountRepository;
       

        public UnitOfWork(AccountContext accountContext)
        {
            this.accountContext = accountContext;
        }

        public IPersonalAccountRepository PersonalAccountRepository
        {
            get
            {
                return personalAccountRepository = personalAccountRepository ?? new PersonalAccountRepository(accountContext);
            }
        }

        public ISaveAccountRepository SaveAccountRepository
        {
            get
            {
                return saveAccountRepository = saveAccountRepository ?? new SaveAccountRepository(accountContext);
            }
        }

        public IWorkAccountRepository WorkAccountRepository
        {
            get
            {
                return workAccountRepository = workAccountRepository ?? new WorkAccountRepository(accountContext);
            }
        }


        public async Task CommitAsync()
        {
            await accountContext.SaveChangesAsync();
        }
    }
}
