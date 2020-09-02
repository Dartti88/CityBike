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
            ICityBikeDataFetcher fetcher;//= new ICityBikeDataFetcher();

            //Online?
            if (args.Length > 1)
            {
                if (args[1].Equals("realtime") || args[1].Equals("online"))
                {
                    fetcher = new RealTimeCityBikeDataFetcher();
                    //Console.WriteLine("Realtime data: " + await fetcher.GetBikeCountInStation(args[0]));
                }
                //Offline?
                else
                {
                    fetcher = new OfflineCityBikeDataFetcher();
                    //OfflineCityBikeDataFetcher fetcher_offline = new OfflineCityBikeDataFetcher();
                    // Console.WriteLine("Offline data: " + await fetcher.GetBikeCountInStation(args[0]));
                }
            }
            else //Do both
            {
                fetcher = new OfflineCityBikeDataFetcher();
                //RealTimeCityBikeDataFetcher fetcher = new RealTimeCityBikeDataFetcher();
                //Console.WriteLine("Realtime data: " + await fetcher.GetBikeCountInStation(args[0]));

                //OfflineCityBikeDataFetcher fetcher_offline = new OfflineCityBikeDataFetcher();
                //Console.WriteLine("Offline data: " + await fetcher.GetBikeCountInStation(args[0]));
            }
            Console.WriteLine("Realtime data: " + await fetcher.GetBikeCountInStation(args[0]));
        }
    }
}

