using AuctionRepo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionRepo
{
    public class DBContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
    }
}
