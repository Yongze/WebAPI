using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

namespace Web.Implementations
{
    public class AuctionOperations : IAuctionOperations
    {
        private readonly HttpClient _httpClient;
        public AuctionOperations(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string CalculateWinner(int itemId)
        {
            HttpResponseMessage res = _httpClient.GetAsync("https://localhost:44345/items/GetWinner/" + itemId).Result;
            if (res.IsSuccessStatusCode)
            {
                return res.Content.ReadAsStringAsync().Result;
            }
            throw new InvalidOperationException($"Unable acquire item winner, {res.StatusCode}");
        }

        public List<Item> ListAllItems()
        {
            HttpResponseMessage res = _httpClient.GetAsync("https://localhost:44345/items/get").Result;
            if (res.IsSuccessStatusCode)
            {
                return res.Content.ReadAsAsync<List<Item>>().Result;
            }
            throw new InvalidOperationException($"Unable acquire item winner, {res.StatusCode}");
        }

        public List<Item> Render()
        {
            List<Item> list = ListAllItems();
            foreach (Item i in list)
            {
                i.Winner = CalculateWinner(i.ItemId);
            }
            return list;
        }
    }
}
