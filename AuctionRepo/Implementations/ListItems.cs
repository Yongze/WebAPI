using AuctionRepo.Interfaces;
using AuctionRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionRepo.Implementations
{
    public class ListItems : IListItems
    {
        private readonly DBContext _context;
        public ListItems(DBContext context)
        {
            _context = context;
        }

        public List<Item> ListAllItem()
        {
            return _context.Items.ToList();
        }
    }
}
