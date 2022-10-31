using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjWeb31102022.Models;

namespace ProjWeb31102022.Data
{
    public class ProjWeb31102022Context : DbContext
    {
        public ProjWeb31102022Context (DbContextOptions<ProjWeb31102022Context> options)
            : base(options)
        {
        }

        public DbSet<ProjWeb31102022.Models.Witch> Witch { get; set; }
    }
}
