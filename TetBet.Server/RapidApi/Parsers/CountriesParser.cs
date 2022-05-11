using System.Collections.Generic;

namespace TetBet.Server.RapidApiParsers
{
    public struct Country
    {
        public string name;
        public string code;
    }

    public class CountriesParser
    {
        public List<Country> countriesList = new List<Country>();
        public void parse(string json)
        {
            var myJObject = JObject.Parse(json);

            string response = myJObject.SelectToken("response").ToString();

            JArray a = JArray.Parse(response);

            foreach (JObject o in a.Children<JObject>())
            {
                Country country = new Country();
                country.name = o.SelectToken("name").Value<string>();
                country.code = o.SelectToken("code").Value<string>();

                countriesList.Add(country);
            }
        }
    }
}