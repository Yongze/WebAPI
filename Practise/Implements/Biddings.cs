using Practise.Interfaces;
using Practise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practise.Implements
{
    public class Biddings : IBiddings, IListBiddings
    {
        private readonly BiddingsContext _context;

        public Biddings(BiddingsContext context)
        {
            _context = context;
        }

        public bool Bid(BidRequest bid)
        {
            _context.Bids.Add(new BidEntity(bid));
            _context.SaveChanges();
            return true;
        }

        public List<BidEntity> GetList(int ItemID)
        {
            return _context.Bids.Where<BidEntity>(o => o.ItemId == ItemID).ToList();
        }
    }
}
