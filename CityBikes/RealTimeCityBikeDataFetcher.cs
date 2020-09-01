using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

class BikeRentalStationList
    {
        public Station[] stations {get; set;}
    }

public class Station
    {
        public string name { get; set; }
        public int bikesAvailable { get; set; }
    }

public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher
{
    static readonly HttpClient client = new HttpClient();
    public async Task<int> GetBikeCountInStation(string stationName)
        {
        try	
            {
            HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/vsillan/game-server-programming-course/master/assignments/bikedata.txt");
            response.EnsureSuccessStatusCode();
            string stations = await response.Content.ReadAsStringAsync();

            //read each line
            foreach(var line in stations.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                 if (line.Contains(stationName))
                    {
                    return Int32.Parse(Regex.Replace(line, "[^0-9]", ""));
                    }
                }
            }

        catch(HttpRequestException) 
            {
            throw new HttpRequestException("Error: Can't get data");
            }

        return 0;
        }
}

public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    static readonly HttpClient client = new HttpClient();

    //static BikeRentalStationList list = new BikeRentalStationList();

    public async Task<int> GetBikeCountInStation(string stationName)
    {
        try	
            {
            HttpResponseMessage response = await client.GetAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
            response.EnsureSuccessStatusCode();
            string stations = await response.Content.ReadAsStringAsync();
            BikeRentalStationList list = JsonConvert.DeserializeObject<BikeRentalStationList>(stations);

            for (int i = 0; i < list.stations.Length; i++)
                {
                if (list.stations[i].name.Equals(stationName))
                    {
                    return list.stations[i].bikesAvailable;
                    }
                }
                
            }
        catch(HttpRequestException) 
            {
            throw new HttpRequestException("Error: Can't get data");
            }
        /*
        catch(NotFoundException) 
            {
            throw new NotFoundException("Not found: Station");
            }
        */
        return 0;
    }

}