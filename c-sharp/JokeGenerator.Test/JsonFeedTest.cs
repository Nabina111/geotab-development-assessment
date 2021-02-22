using JokeGenerstor.DAL;
using NUnit.Framework;

namespace JokeGenerator.Test
{
    public class Tests
    {
        //Declaration
        JsonFeed jfed = new JsonFeed("https://api.chucknorris.io", 0);

        [Test]
        public void GetCategoriesTest()
        {
            var result = JsonFeed.GetCategories();
            
            Assert.NotNull(result);
        }

        [Test]
        public void GetRandomJokesTest_withNamevaluesTest()
        {
            
            var result = JsonFeed.GetRandomJokes("NNN", "test", "dev");
           
            Assert.NotNull(result);

        }


        [Test]
        public void GetRandomJokesTest_withoutnamevaluesTest()
        {
            var result1 = JsonFeed.GetRandomJokes("", "", "animal");

            var result2 = JsonFeed.GetRandomJokes(null, null, "animal");


            Assert.NotNull(result1);

            Assert.NotNull(result2);

        }

        [Test]
        public void GetRandomJokesTest_withWrongValuesTest()
        {
            var result1 = JsonFeed.GetRandomJokes("", "", "");

            var result2 = JsonFeed.GetRandomJokes(null, null, "");


            Assert.AreEqual(result1[0], "Input string not in correct format");
            Assert.AreEqual(result1[0], "Input string not in correct format");

            Assert.NotNull(result2);
        }
    }
}