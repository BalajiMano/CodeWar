using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public partial class Program
{
    [Benchmark]
    public  void Approach1()
    {
        Console.WriteLine("Hello, World!");
        List<string> cities = new() { "BANGKOK", "ALGIERS", "ISTANBUL", "NASSAU", "JEDDAH", "WINNIPEG", "GUATEMALA CITY", "YASUJ", "EDMONTON", "FECAMP", "ROME", "PLOVDIV", "OSAKA", "UTRECHT", "DAR ES SALAAM", "KUALA LUMPUR", "MAZAR E SHARIF", "SHANGHAI", "TOKYO", "LUCKNOW", "HYDERABAD" };

        var StartingCity = "BANGKOK";

        var ResultCity = new List<string>();

        //var LocalCities=cities;
        var NxtCity = NextCity(StartingCity[StartingCity.Length - 1], cities);
        ResultCity.Add(NxtCity);
        //LocalCities.Remove(NxtCity);
        foreach (var city in cities)
        {
            if (!ResultCity.Contains(city))
            {
                NxtCity = NextCity(NxtCity[NxtCity.Length - 1], cities);
                ResultCity.Add(NxtCity);
            }
            // LocalCities.Remove(NxtCity);
        }
        foreach (var city in ResultCity)
        {
           // Console.WriteLine($"{city}");
        }
        Console.ReadLine();
    }
       public  string NextCity(char CurCity, IEnumerable<string> CityList)
        {
            string NxtCity = "";
            foreach (var city in CityList)
            {
                if (city[0] == CurCity)
                {
                    NxtCity = city;
                }
            }
            return NxtCity;
        }
    
}

public class FindNextCity
{
    public static void Main()
    {
BenchmarkRunner.Run<Program>();
       // Console.WriteLine(summary);
       // Program.Approach1();
        //Program.Approach2();
    }
}