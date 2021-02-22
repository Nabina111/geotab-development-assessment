using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerstor.DAL
{
    interface IGetIUItem
    {
        public string[] GetRandomJokes(string category, int number, Tuple<string, string> names);
        public  string[] getCategories();

        public  Tuple<string, string> GetNames();

    }
}
