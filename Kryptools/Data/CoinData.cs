using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Kryptools;

namespace Kryptools.Data
{
    public class CoinData
    {

        public DataTable GetMarket()
        {
            DataTable market = new DataTable();

            DataColumn id = market.Columns.Add("id", typeof(string)); 
            DataColumn  name = market.Columns.Add("Name", typeof(string));
            DataColumn symbol = market.Columns.Add("Symbol", typeof(string)); 
            DataColumn rank = market.Columns.Add("Rank", typeof(string));
            DataColumn price_usd = market.Columns.Add("Price(USD)", typeof(string));
            DataColumn price_btc = market.Columns.Add("Price(BTC)", typeof(string)); ;
            DataColumn _24h_volume_usd = market.Columns.Add("Volume(24h)", typeof(string));
            DataColumn market_cap_usd = market.Columns.Add("Market", typeof(string));
            DataColumn available_supply = market.Columns.Add("Supply", typeof(string));
            DataColumn total_supply = market.Columns.Add("Total Supply", typeof(string));
            DataColumn percent_change_1h = market.Columns.Add("Change(% - 1h)", typeof(string));
            DataColumn percent_change_24h = market.Columns.Add("Change(% - 24h)", typeof(string));
            DataColumn percent_change_7d = market.Columns.Add("Change(% - 7d)", typeof(string));
            DataColumn last_updated = market.Columns.Add("Last Updated", typeof(string));



            string url = "https://api.coinmarketcap.com/v1/";

            var client = new RestClient(url);

            var request = new RestRequest("ticker", Method.POST);

            IRestResponse response = client.Execute(request);
            var content = response.Content;


            List<Coin> c = JsonConvert.DeserializeObject<List<Coin>>(content);

 
            foreach(Coin j in c)
            {

                market.Rows.Add(j.Id,
                                j.Name,
                                j.Symbol,
                                j.Rank,
                                j.Price_usd,
                                j.Price_btc,
                                j.__24h_volume_usd,
                                j.Market_cap_usd,
                                j.Available_supply,
                                j.Total_supply,
                                j.Percent_change_1h,
                                j.Percent_change_24h,
                                j.Percent_change_7d,
                                j.Last_updated);
            }
            

           return market;

        }

        public List<string> GetCoinList()
        {
            List<string> CoinList = new List<string>();


            string url = "https://api.coinmarketcap.com/v1/";

            var client = new RestClient(url);
            var request = new RestRequest("ticker", Method.POST);


            IRestResponse response = client.Execute(request);
            var content = response.Content;            

            List<Coin> c = JsonConvert.DeserializeObject<List<Coin>>(content);


            foreach (Coin j in c)
            {
                CoinList.Add("[" + j.Symbol.ToUpper() + "] - " + j.Name + " - (" + Convert.ToDecimal(j.Price_btc).ToString() + "btc)");
            }
            
            return CoinList;
        }

        public DataTable GetCoinPrices()
        {
            DataTable Market = GetMarket();
            DataTable Prices = new DataTable();

            DataColumn id = Prices.Columns.Add("id", typeof(string));
            DataColumn name = Prices.Columns.Add("Name", typeof(string));
            DataColumn symbol = Prices.Columns.Add("Symbol", typeof(string));
            DataColumn value_btc = Prices.Columns.Add("Price(B)", typeof(decimal));

            foreach (DataRow Row in Market.Rows)
            {
                Prices.Rows.Add(Row["id"], Row["name"], Row["symbol"], Convert.ToDecimal(Row["Price(BTC)"]));
            }


            return Prices;

        }

        public DataTable GetCoinPrices(string ID)
        {
            DataTable market = new DataTable();
            DataTable price = new DataTable();

            DataColumn id = market.Columns.Add("id", typeof(string));
            DataColumn name = market.Columns.Add("Name", typeof(string));
            DataColumn symbol = market.Columns.Add("Symbol", typeof(string));
            DataColumn rank = market.Columns.Add("Rank", typeof(string));
            DataColumn price_usd = market.Columns.Add("Price(USD)", typeof(string));
            DataColumn price_btc = market.Columns.Add("Price(BTC)", typeof(string)); ;
            DataColumn _24h_volume_usd = market.Columns.Add("Volume(24h)", typeof(string));
            DataColumn market_cap_usd = market.Columns.Add("Market", typeof(string));
            DataColumn available_supply = market.Columns.Add("Supply", typeof(string));
            DataColumn total_supply = market.Columns.Add("Total Supply", typeof(string));
            DataColumn percent_change_1h = market.Columns.Add("Change(% - 1h)", typeof(string));
            DataColumn percent_change_24h = market.Columns.Add("Change(% - 24h)", typeof(string));
            DataColumn percent_change_7d = market.Columns.Add("Change(% - 7d)", typeof(string));
            DataColumn last_updated = market.Columns.Add("Last Updated", typeof(string));

            string url = "https://api.coinmarketcap.com/v1/";

            var client = new RestClient(url);
            var request = new RestRequest("ticker/{id}", Method.POST);
            request.AddUrlSegment("id", ID);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            
            Coin j = JsonConvert.DeserializeObject<Coin>(content);

          

            market.Rows.Add(j.Id,
                            j.Name,
                            j.Symbol,
                            j.Rank,
                            j.Price_usd,
                            j.Price_btc,
                            j.__24h_volume_usd,
                            j.Market_cap_usd,
                            j.Available_supply,
                            j.Total_supply,
                            j.Percent_change_1h,
                            j.Percent_change_24h,
                            j.Percent_change_7d,
                            j.Last_updated);

            foreach (DataRow dr in market.Rows)
                price.Rows.Add(j.Id, j.Symbol, j.Price_btc);


            return price;

        }
    }
}
