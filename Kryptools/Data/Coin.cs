using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptools.Data
{
    public class Coin
    {
        //public int Rank { get; set; }
        //public byte[] Icon { get; set; }
        //public string Name { get; set; }
        //public string Symbol {get; set; }
        //public decimal MarketCap { get; set; }
        //public decimal Price { get; set; }
        //public int CirculatingSupply { get; set; }
        //public decimal Volume24h { get; set; }
        //public float Change24h { get; set; }

        private string id;
        private string name;
        private string symbol;
        private string rank;
        private string price_usd;
        private string price_btc;
        private string _24h_volume_usd;
        private string market_cap_usd;
        private string available_supply;
        private string total_supply;
        private string percent_change_1h;
        private string percent_change_24h;
        private string percent_change_7d;
        private string last_updated;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public string Rank { get => rank; set => rank = value; }
        public string Price_usd { get => price_usd; set => price_usd = value; }
        public string Price_btc { get => price_btc; set => price_btc = value; }
        [JsonProperty(PropertyName = "24h_volume_usd")]
        public string __24h_volume_usd { get => this._24h_volume_usd; set => this._24h_volume_usd = value; }
        public string Market_cap_usd { get => market_cap_usd; set => market_cap_usd = value; }
        public string Available_supply { get => available_supply; set => available_supply = value; }
        public string Total_supply { get => total_supply; set => total_supply = value; }
        public string Percent_change_1h { get => percent_change_1h; set => percent_change_1h = value; }
        public string Percent_change_24h { get => percent_change_24h; set => percent_change_24h = value; }
        public string Percent_change_7d { get => percent_change_7d; set => percent_change_7d = value; }
        public string Last_updated { get => last_updated; set => last_updated = value; }
    }
}
