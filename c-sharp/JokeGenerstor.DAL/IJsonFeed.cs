using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerstor.DAL
{
    interface IJsonFeed
    {
        public string[] GetRandomJokes(string firstname, string lastname, string category);

        public  dynamic Getnames();

        public string[] GetCategories();


    }
}
