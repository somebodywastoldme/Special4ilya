using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IPersonalAccountRepository PersonalAccountRepository { get; }
        IWorkAccountRepository WorkAccountRepository { get; }
        ISaveAccountRepository SaveAccountRepository { get; }
        Task CommitAsync();
    }
}
