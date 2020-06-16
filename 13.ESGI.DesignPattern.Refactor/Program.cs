using System;

namespace _13.ESGI.DesignPattern.Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Forecast forecast = new Forecast();
            var result1 = forecast.predict("paris", DateTime.Now, true);
            Console.WriteLine(result1);

            var result2 = forecast.predict("paris", DateTime.Now, false);
            Console.WriteLine(result2);

            Console.ReadLine();
        }
    }
}
