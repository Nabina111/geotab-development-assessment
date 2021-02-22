using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;

namespace JokeGenerstor.DAL
{
    public class GetUIItems : IGetUIItems
    {
        public string[] GetRandomJokes(string category, int number, Tuple<string, string> names)
        {
            try
            {
                new JsonFeed("https://api.chucknorris.io", number);
                return JsonFeed.GetRandomJokes(names?.Item1, names?.Item2, category);
            }
            catch (Exception Ex)
            {
                return new string[] { "Error in connection" };

            }

        }
        public string[] getCategories()
        {
            try
            {
                new JsonFeed("https://api.chucknorris.io", 0);
                return JsonFeed.GetCategories();
            }
            catch(Exception Ex)
            {
                return new string[] { "Error in connection" };
            }
        }

        public Tuple<string, string> GetNames()
        {
            try
            {
                new JsonFeed("https://www.names.privserv.com/api/", 0);
                dynamic result = JsonFeed.Getnames();
                return Tuple.Create(result.name.ToString(), result.surname.ToString());
            }
            catch(Exception Ex)
            {
                return Tuple.Create("Error in Connection", " Please Try again Later");
            }
        }
    }
}
