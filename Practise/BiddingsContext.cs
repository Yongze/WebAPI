using Microsoft.EntityFrameworkCore;
using Practise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practise
{
    public class BiddingsContext:DbContext
    {
        public BiddingsContext(DbContextOptions<BiddingsContext> options) : base(options)
        {

        }
        public DbSet<BidEntity> Bids { get; set; }
    }
}
