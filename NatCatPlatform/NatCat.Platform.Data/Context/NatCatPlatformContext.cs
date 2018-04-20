using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NatCat.Platform.Data.Entities;

namespace NatCat.Platform.Data.Context
{
    public class NatCatPlatformContext : DbContext
    {
        public NatCatPlatformContext (DbContextOptions<NatCatPlatformContext> options)
            : base(options)
        {
        }

        public DbSet<NatCat.Platform.Data.Entities.Story> Story { get; set; }
    }
}
