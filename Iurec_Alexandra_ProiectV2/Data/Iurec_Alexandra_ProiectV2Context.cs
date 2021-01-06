using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Iurec_Alexandra_ProiectV2.Models;

namespace Iurec_Alexandra_ProiectV2.Data
{
    public class Iurec_Alexandra_ProiectV2Context : DbContext
    {
        public Iurec_Alexandra_ProiectV2Context (DbContextOptions<Iurec_Alexandra_ProiectV2Context> options)
            : base(options)
        {
        }

        public DbSet<Iurec_Alexandra_ProiectV2.Models.Contract> Contract { get; set; }

        public DbSet<Iurec_Alexandra_ProiectV2.Models.OurService> OurService { get; set; }

        public DbSet<Iurec_Alexandra_ProiectV2.Models.Employee> Employee { get; set; }
    }
}
