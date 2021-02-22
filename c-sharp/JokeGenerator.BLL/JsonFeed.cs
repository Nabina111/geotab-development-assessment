using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace JokeGenerstor.DAL
{
    public class JsonFeed
    {
        private static string _url = "";
        public JsonFeed(string endpoint, int results)
        {
            _url = endpoint;
        }
        public static string[] GetRandomJokes(string firstname, string lastname, string category)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_url);
                string url = "jokes/random";
                if (category != null)
                {
                    if (url.Contains('?'))
                        url += "&";
                    else url += "?";
                    url += "category=";
                    url += category;
                }

                string joke = Task.FromResult(client.GetStringAsync(url).Result).Result;

                if (!(string.IsNullOrEmpty(firstname) && string.IsNullOrEmpty(lastname)))
                {
                    int index = joke.IndexOf("Chuck Norris");
                    string firstPart = joke.Substring(0, index);
                    string secondPart = joke.Substring(0 + index + "Chuck Norris".Length, joke.Length - (index + "Chuck Norris".Length));
                    joke = firstPart + " " + firstname + " " + lastname + secondPart;
                }

                return new string[] { JsonConvert.DeserializeObject<dynamic>(joke).value };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// returns an object that contains name and surname
        /// </summary>
        /// <param name="client2"></param>
        /// <returns></returns>
        public static dynamic Getnames()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_url);
                var result = client.GetStringAsync("").Result;
                return JsonConvert.DeserializeObject<dynamic>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string[] GetCategories()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_url);

                return new string[] { Task.FromResult(client.GetStringAsync("jokes/categories").Result).Result };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
