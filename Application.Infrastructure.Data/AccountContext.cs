using Application.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<PersonalAccount> PersonalAccount { get; set; }
        public DbSet<SaveAccount> SaveAccount { get; set; }
        public DbSet<WorkAccount> WorkAccount { get; set; }
    }
}
