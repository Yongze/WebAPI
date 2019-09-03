using Practise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practise.Interfaces
{
    public interface IListBiddings
    {
        List<BidEntity> GetList(int ItemID);
    }
}
