using Application.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core.Entities;
using Microsoft.AspNetCore.Cors;
using Application.Infrastructure.Services;
using Application.Core.Interfaces.Services;

namespace Application.API.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public IAccountService accountService;
        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpPost("transfer/personal/save")]
        public async Task<IActionResult> TransferFromPersonalAccountToSaveAccount(double amount, string description = "None")
        {
            await accountService.TransferFromPersonalToSaveAsync(amount, description);
            return Ok();
        }
        [HttpPost("transfer/personal/work")]
        public async Task<IActionResult> TransferFromPersonalAccountToWorkAccount(double amount, string description = "None")
        {
            await accountService.TransferFromPersonalToWorkAsync(amount, description);
            return Ok();
        }
        [HttpPost("transfer/save/personal")]
        public async Task<IActionResult> TransferFromSaveAccountToPersonalAccount(double amount, string description = "None")
        {
            await accountService.TransferFromSaveToPersonalAsync(amount, description);
            return Ok();
        }
        [HttpPost("transfer/save/work")]
        public async Task<IActionResult> TransferFromSaveAccountToWorkAccount(double amount, string description = "None")
        {
            await accountService.TransferFromSaveToWorkAsync(amount, description);
            return Ok();
        }
        [HttpPost("transfer/work/personal")]
        public async Task<IActionResult> TransferFromWorkAccountToPersonalAccount(double amount, string description = "None")
        {
            await accountService.TransferFromWorkToPersonalAsync(amount, description);
            return Ok();
        }
        [HttpPost("transfer/work/save")]
        public async Task<IActionResult> TransferFromWorkAccountToSaveAccount(double amount, string description = "None")
        {
            await accountService.TransferFromWorkToSaveAsync(amount, description);
            return Ok();
        }
        [HttpPost("operate/personal")]
        public async Task<IActionResult> AddToPersonalAccount(bool operation, double amount, string description = "None")
        {
            await accountService.OperateToPersonalAccount(operation, amount, description);
            return Ok();
        }
        [HttpPost("operate/save")]
        public async Task<IActionResult> AddToSaveAccount(bool operation, double amount, string description = "None")
        {
            await accountService.OperateToSaveAccount(operation, amount, description);
            return Ok();
        }
        [HttpPost("operate/work")]
        public async Task<IActionResult> AddToWorkAccount(bool operation, double amount, string description = "None")
        {
            await accountService.OperateToWorkAccount(operation, amount, description);
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(int accountNumber)
        {
            await accountService.GetAll(accountNumber);

            return Ok();
        }

        [HttpGet("all/{description}")]
        public async Task<IActionResult> GetAllByDescription(string description, int accountNumber)
        {
            await accountService.GetAllByDescription(description, accountNumber);

            return Ok();
        }

        [HttpGet("added")]
        public async Task<IActionResult> GetAllAdded(int accountNumber)
        {
            await accountService.GetAllAdded(accountNumber);

            return Ok();
        }
        [HttpGet("subtracted")]
        public async Task<IActionResult> GetAllSubtracted(int accountNumber)
        {
            await accountService.GetAllSubtract(accountNumber);

            return Ok();
        }

    }
}
