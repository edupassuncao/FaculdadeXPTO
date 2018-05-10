using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TogglerService.Model;

namespace TogglerService.DTO
{
    public class TogglerContext : DbContext
    {
        public TogglerContext(DbContextOptions<TogglerContext> options) : base (options)
        {
        }

        public DbSet<Toggler> Toggler { get; set; }



    }
}
