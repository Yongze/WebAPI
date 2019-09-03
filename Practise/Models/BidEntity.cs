using System;
using System.ComponentModel.DataAnnotations;

namespace Practise.Models
{
    public class BidEntity
    {
        [Key]
        public int BidId { get; set; }
        public int ItemId { get; set; }
        public string Email { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        public DateTime? TimeStamp { get; set; } = DateTime.Now;

        public BidEntity()
        {

        }

        public BidEntity(BidRequest bid)
        {
            ItemId = bid.ItemId;
            Email = bid.Email;
            Price = bid.Price;
            Comment = bid.Comment;
        }
    }
}