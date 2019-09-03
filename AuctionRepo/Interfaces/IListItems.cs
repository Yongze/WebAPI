using AuctionRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionRepo.Interfaces
{
    public interface IListItems
    {
        List<Item> ListAllItem();
    }
}
