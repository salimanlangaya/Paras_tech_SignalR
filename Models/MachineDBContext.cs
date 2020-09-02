using Microsoft.EntityFrameworkCore;
using System;

namespace Paras_tech_SignalR.Models
{
    public class MachineDBContext: DbContext
    {
        public MachineDBContext(DbContextOptions<MachineDBContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Machine> Machines { get; set; }
    }

}
