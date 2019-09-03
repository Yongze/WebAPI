using AuctionRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionRepo.Implementations
{
    public class Winner : IWinner
    {
        private readonly DBContext _context;

        public Winner(DBContext context)
        {
            _context = context;
        }

        public string Calculate(int itemID)
        {
            string ans = "";
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select Email,Price from Bids where Bidid = (select MAX(t.BidId) from (select BidId from Bids where Price = (select MAX(Price) from Bids inner join Items on Bids.ItemId=Items.ItemId where Bids.ItemId={itemID} and Items.EndBid > Bids.[TimeStamp])) as t)";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            ans = result.GetString(0) + " with Price of $" + result.GetDecimal(1);
                        }
                    }
                    else
                    {
                        ans = "$10";
                    }
                }
                _context.Database.CloseConnection();
            }
            return ans;
        }
    }
}
