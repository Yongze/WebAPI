using AuctionRepo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private HttpClient _httpClient = new HttpClient();
        [TestMethod]
        public void TestMethod1()
        {
            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44399/items/get").Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Item> itemList = response.Content.ReadAsAsync<List<Item>>().Result;
            Assert.IsNotNull(itemList);
            Assert.IsTrue(itemList.Count > 0);
        }
    }
}
