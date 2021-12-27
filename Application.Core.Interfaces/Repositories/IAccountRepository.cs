using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task AddAsync(double amount, string description);
        Task<double> GetAllSubtract();
        Task<double> GetAllByDescription(string description);
        Task<double> GetAllAdded();
        Task<double> GetAll();
    }
}
