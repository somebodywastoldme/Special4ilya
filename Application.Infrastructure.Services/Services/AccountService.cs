using Application.Core.Interfaces;
using Application.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task TransferFromPersonalToWorkAsync(double amount, string description)
        {
            await unitOfWork.PersonalAccountRepository.AddAsync(-amount, description);
            await unitOfWork.WorkAccountRepository.AddAsync(amount, description);
        }
        public async Task TransferFromPersonalToSaveAsync(double amount, string description)
        {
            await unitOfWork.PersonalAccountRepository.AddAsync(-amount, description);
            await unitOfWork.SaveAccountRepository.AddAsync(amount, description);
        }
        public async Task TransferFromWorkToPersonalAsync(double amount, string description)
        {
            await unitOfWork.WorkAccountRepository.AddAsync(-amount, description);
            await unitOfWork.PersonalAccountRepository.AddAsync(amount, description);
        }
        public async Task TransferFromWorkToSaveAsync(double amount, string description)
        {
            await unitOfWork.WorkAccountRepository.AddAsync(-amount, description);
            await unitOfWork.SaveAccountRepository.AddAsync(amount, description);
        }
        public async Task TransferFromSaveToPersonalAsync(double amount, string description)
        {
            await unitOfWork.SaveAccountRepository.AddAsync(-amount, description);
            await unitOfWork.PersonalAccountRepository.AddAsync(amount, description);
        }
        public async Task TransferFromSaveToWorkAsync(double amount, string description)
        {
            await unitOfWork.SaveAccountRepository.AddAsync(-amount, description);
            await unitOfWork.WorkAccountRepository.AddAsync(amount, description);
        }

        public async Task OperateToPersonalAccount(bool operation, double amount, string description)
        {
            if (operation == true)
            {
                await unitOfWork.PersonalAccountRepository.AddAsync(amount, description);
            }
            else
            {
                await unitOfWork.PersonalAccountRepository.AddAsync(-amount, description);
            }
        }
        public async Task OperateToSaveAccount(bool operation, double amount, string description)
        {
            if (operation == true)
            {
                await unitOfWork.SaveAccountRepository.AddAsync(amount, description);
            }
            else
            {
                await unitOfWork.SaveAccountRepository.AddAsync(-amount, description);
            }
        }
        public async Task OperateToWorkAccount(bool operation, double amount, string description)
        {
            if (operation == true)
            {
                await unitOfWork.WorkAccountRepository.AddAsync(amount, description);
            }
            else
            {
                await unitOfWork.WorkAccountRepository.AddAsync(-amount, description);
            }
        }

        public async Task GetAll(int accountNumber)
        {
            switch (accountNumber)
            {
                case 1:
                    await unitOfWork.PersonalAccountRepository.GetAll();
                    break;
                case 2:
                    await unitOfWork.SaveAccountRepository.GetAll();
                    break;
                case 3:
                    await unitOfWork.WorkAccountRepository.GetAll();
                    break;
                default:
                    break;
            }
        }
        public async Task GetAllAdded(int accountNumber)
        {
            switch (accountNumber)
            {
                case 1:
                    await unitOfWork.PersonalAccountRepository.GetAllAdded();
                    break;
                case 2:
                    await unitOfWork.SaveAccountRepository.GetAllAdded();
                    break;
                case 3:
                    await unitOfWork.WorkAccountRepository.GetAllAdded();
                    break;
                default:
                    break;
            }
        }
        public async Task GetAllSubtract(int accountNumber)
        {
            switch (accountNumber)
            {
                case 1:
                    await unitOfWork.PersonalAccountRepository.GetAllSubtract();
                    break;
                case 2:
                    await unitOfWork.SaveAccountRepository.GetAllSubtract();
                    break;
                case 3:
                    await unitOfWork.WorkAccountRepository.GetAllSubtract();
                    break;
                default:
                    break;
            }
        }
        public async Task GetAllByDescription(string description, int accountNumber)
        {
            switch (accountNumber)
            {
                case 1:
                    await unitOfWork.PersonalAccountRepository.GetAllByDescription(description);
                    break;
                case 2:
                    await unitOfWork.SaveAccountRepository.GetAllByDescription(description);
                    break;
                case 3:
                    await unitOfWork.WorkAccountRepository.GetAllByDescription(description);
                    break;
                default:
                    break;
            }
        }
    }
}
