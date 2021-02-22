using System;
using JokeGenerstor.DAL;

namespace ConsoleApp1
{
    public class Program
    {
        static char key;
        private static IGetUIItems uiService;
        static Program()
        {
            uiService = new GetUIItems();
        }


        static void Main(string[] args)
        {
            Tuple<string, string> names = null;
            string[] results = new string[50];
            ConsolePrinter printer = new ConsolePrinter();
            printer.Value("Press ? to get instructions.").ToString();
            if (Console.ReadLine() == "?")
            {
                while (true)
                {
                    try
                    {
                        printer.Value("Press c to get categories").ToString();
                        printer.Value("Press r to get random jokes").ToString();
                        key = Convert.ToChar(Console.ReadLine());
                        if (key == 'c')
                        {
                            results = uiService.getCategories();
                            PrintResults(results, printer);
                        }
                        if (key == 'r')
                        {
                            printer.Value("Want to use a random name? y/n").ToString();
                            key = Convert.ToChar(Console.ReadLine());
                            if (key == 'y')
                                names = uiService.GetNames();
                            printer.Value("Want to specify a category? y/n").ToString();
                            key = Convert.ToChar(Console.ReadLine());
                            if (key == 'y')
                            {
                                printer.Value("How many jokes do you want? (1-9)").ToString();
                                int n = Int32.Parse(Console.ReadLine());
                                printer.Value("Enter a category;").ToString();
                                results = uiService.GetRandomJokes(Console.ReadLine(), n, names);
                                PrintResults(results, printer);
                            }
                            else
                            {
                                printer.Value("How many jokes do you want? (1-9)").ToString();
                                int n = Int32.Parse(Console.ReadLine());
                                results = uiService.GetRandomJokes(null, n, names);
                                PrintResults(results, printer);
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        PrintResults(new string[] { "Error in input Value. Please enter the correct values for input!" }, printer);
                        continue;
                    }
                }
            }

        }

        private static void PrintResults(string[] results, ConsolePrinter printer)
        {
            printer.Value("[" + string.Join(",", results) + "]").ToString();
        }

        private static void GetEnteredKey(ConsoleKeyInfo consoleKeyInfo)
        {

            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
            }
        }

    }
}
