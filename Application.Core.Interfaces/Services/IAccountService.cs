using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task TransferFromPersonalToWorkAsync(double amount, string description);
        Task TransferFromPersonalToSaveAsync(double amount, string description);
        Task TransferFromWorkToPersonalAsync(double amount, string description);
        Task TransferFromWorkToSaveAsync(double amount, string description);
        Task TransferFromSaveToPersonalAsync(double amount, string description);
        Task TransferFromSaveToWorkAsync(double amount, string description);
        Task OperateToPersonalAccount(bool operation, double amount, string description);
        Task OperateToSaveAccount(bool operation, double amount, string description);
        Task OperateToWorkAccount(bool operation, double amount, string description);
        Task GetAll(int accountNumber);
        Task GetAllAdded(int accountNumber);
        Task GetAllSubtract(int accountNumber);
        Task GetAllByDescription(string description, int accountNumber);

    }
}
