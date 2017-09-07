using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;

namespace Kryptools.Data
{
    class NewsData
    {
        public DataTable GetNews()
        {

            DataTable dtNews = new DataTable();

            DataColumn Title = dtNews.Columns.Add("Title", typeof(string));
            DataColumn SubReddit = dtNews.Columns.Add("SubReddit", typeof(string));
            DataColumn Date = dtNews.Columns.Add("Date", typeof(DateTime));
            DataColumn URL = dtNews.Columns.Add("URL", typeof(string));



            var reddit = new Reddit();

            List<string> subreddits = new List<string>();
            subreddits.Add("/r/CryptoCurrency");
            subreddits.Add("/r/CryptoMarkets");
            subreddits.Add("/r/altcoin");
            subreddits.Add("/r/altcoins");

            foreach (string s in subreddits)
            {
                var subreddit = reddit.GetSubreddit(s);

                subreddit.GetTop(RedditSharp.Things.FromTime.Week);

                foreach (var post in subreddit.GetTop(RedditSharp.Things.FromTime.Week).Take(10))
                {

                    dtNews.Rows.Add(post.Title, post.SubredditName, post.CreatedUTC, post.Url);

                }
            }

            return dtNews;

        }

    }
}
