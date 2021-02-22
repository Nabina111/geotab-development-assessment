using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerstor.DAL
{
    public class GetUIItems : IGetIUItem
    {
        public string[] GetRandomJokes(string category, int number, Tuple<string, string> names)
        {
            new JsonFeed("https://api.chucknorris.io", number);
            return  JsonFeed.GetRandomJokes(names?.Item1, names?.Item2, category);
        }

        public string[] getCategories()
        {
            new JsonFeed("https://api.chucknorris.io", 0);
            return  JsonFeed.GetCategories();
        }

        public Tuple<string, string> GetNames()
        {
            new JsonFeed("https://www.names.privserv.com/api/", 0);
            dynamic result = JsonFeed.Getnames();
            return  Tuple.Create(result.name.ToString(), result.surname.ToString());
        }
    }
}
