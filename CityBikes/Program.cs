using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityBikes
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            if (args[0].Any(char.IsDigit))
                {
                throw new ArgumentException("Invalid argument: String contains numbers");
                }

            Console.WriteLine(args[0]);

            //Online?
            if (args.Length>1)
            {
            if (args[1].Equals("realtime") || args[1].Equals("online") )
                {
                RealTimeCityBikeDataFetcher fetcher = new RealTimeCityBikeDataFetcher();
                Console.WriteLine("Realtime data: " + await fetcher.GetBikeCountInStation(args[0]));
                }
            //Offline?
            else if (args[1].Equals("offline"))
                {
                OfflineCityBikeDataFetcher fetcher_offline = new OfflineCityBikeDataFetcher();
                Console.WriteLine("Offline data: " + await fetcher_offline.GetBikeCountInStation(args[0]));
                }
            }
            else //Do both
                {
                RealTimeCityBikeDataFetcher fetcher = new RealTimeCityBikeDataFetcher();
                Console.WriteLine("Realtime data: " + await fetcher.GetBikeCountInStation(args[0]));
                
                OfflineCityBikeDataFetcher fetcher_offline = new OfflineCityBikeDataFetcher();
                Console.WriteLine("Offline data: " + await fetcher_offline.GetBikeCountInStation(args[0]));
                }
            
        }
    }
}

