using System;
using System.Collections.Generic;
using System.Linq;

namespace Tehtava2
{
    class Program : ItemSearch
    {
        static void Main(string[] args)
        {
            int player_num = 100;
            Dictionary<Guid, Player> players = new Dictionary<Guid, Player>();
            var rand = new Random();

            for (int i = 0; i < player_num; i++)
            {
                Guid guid = Guid.NewGuid();
                if (!players.ContainsKey(guid))
                {
                    Player player = new Player();
                    player.Id = guid;
                    player.Items = new List<Item>();

                    for (int j = 0; j < 10; j++)
                    {
                        Item item = new Item();
                        item.Id = Guid.NewGuid();
                        Console.WriteLine(item.Id);
                        item.Level = rand.Next(21);
                        player.Items.Add(item);
                    }

                    players.Add(guid, player);

                    //TEST - Teht2
                    //Item found_item = player.GetHighestLevelItem();

                    //TEST - Teht3
                    /*
                    Item[] lista = GetItemsWithLinq(player);
                    for (int a = 0; a < lista.Length; a++)
                    {
                        Console.WriteLine(lista[a].Id);
                    }
                    */

                    //Test - Teht4 
                    //Console.WriteLine(FirstItem(player).Level);
                    //Console.WriteLine(FirstItemWithLinq(player).Level);

                }
                else
                {
                    i--;
                }
            }
        }
    }

    public static class PlayerExtension
    {
        public static Item GetHighestLevelItem(this Player player)
        {
            //Console.WriteLine("Test");
            if (player.Items.Any())
            {
                Item selected_item = player.Items[0];

                foreach (var item in player.Items)
                {
                    if (selected_item.Level < item.Level)
                    {
                        selected_item = item;
                    }
                }

                Console.WriteLine("ID: " + selected_item.Id);
                Console.WriteLine("Level: " + selected_item.Level);

                return selected_item;
            }

            return null;
        }
    }



}