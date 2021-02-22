using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerstor.DAL
{
    public interface IGetUIItems
    {
        string[] GetRandomJokes(string category, int number, Tuple<string, string> names);
        string[] getCategories();

        Tuple<string, string> GetNames();

    }
}
