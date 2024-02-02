using BenchmarkDotNet.Attributes;

public partial class  Program
{
    [Benchmark]
    public  void Approach2()
    {
        List<string> cities = new List<string> { "BANGKOK", "ALGIERS", "ISTANBUL", "NASSAU", "JEDDAH", "WINNIPEG", "GUATEMALA CITY", "YASUJ", "EDMONTON", "FECAMP", "ROME", "PLOVDIV", "OSAKA", "UTRECHT", "DAR ES SALAAM", "KUALA LUMPUR", "MAZAR E SHARIF", "SHANGHAI", "TOKYO", "LUCKNOW", "HYDERABAD" };

        var resultCities = GetCitySequence("BANGKOK", cities);

        foreach (var city in resultCities)
        {
         //   Console.WriteLine(city);
        }

        Console.ReadLine();
    }

   public   List<string> GetCitySequence(string startingCity, List<string> cityList)
    {
        var resultCities = new List<string>();
        var cityDictionary = new Dictionary<char, List<string>>();

        // Group cities by their starting letter
        foreach (var city in cityList)
        {
            var firstLetter = city[0];
            if (!cityDictionary.ContainsKey(firstLetter))
            {
                cityDictionary[firstLetter] = new List<string>();
            }
            cityDictionary[firstLetter].Add(city);
        }

        // Start with the given city
        var currentCity = startingCity;

        // Iterate until no more cities can be found
        while (cityDictionary.ContainsKey(currentCity[currentCity.Length - 1]))
        {
            var nextCities = cityDictionary[currentCity[currentCity.Length - 1]];
            var nextCity = nextCities[0]; // Choose the first city with the matching starting letter
            resultCities.Add(nextCity);
            currentCity = nextCity;
        }

        return resultCities;
    }
}