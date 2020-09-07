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
                        //Console.WriteLine(item.Id);
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

                    //Test - Teht5
                    //ProcessEachItem(player, PrintItem);

                    //Test - Teht6
                    /*
                    ProcessEachItem(player,
                        item =>
                        {
                            Console.WriteLine(item.Id);
                            Console.WriteLine(item.Level);
                        });
                    */
                }
                else
                {
                    i--;
                }
            }

            //Teht 7
            player_num = 100;
            List<IPlayer> list_players = new List<IPlayer>();

            for (int i = 0; i < player_num; i++)
            {
                IPlayer player = new Player();
                player.Score = rand.Next(1000);
                list_players.Add(player);
            }

            var list_seleceted_players = new IPlayer[10];

            Console.WriteLine("GAME 1");

            List<IPlayer> list_PlayerForAnotherGame = new List<IPlayer>();
            for (int i = 0; i < player_num; i++)
            {
                IPlayer player = new PlayerForAnotherGame();
                player.Score = rand.Next(1000) + 2000;
                list_PlayerForAnotherGame.Add(player);
            }

            Game<IPlayer> next_game_1 = new Game<IPlayer>(list_players);
            list_seleceted_players = next_game_1.GetTop10Players();

            for (int i = 0; i < list_seleceted_players.Count(); i++)
            {
                Console.WriteLine(list_seleceted_players[i].Score);
            }

            Console.WriteLine("\nGAME 2");

            Game<IPlayer> next_game_2 = new Game<IPlayer>(list_PlayerForAnotherGame);
            list_seleceted_players = next_game_2.GetTop10Players();

            for (int i = 0; i < list_seleceted_players.Count(); i++)
            {
                Console.WriteLine(list_seleceted_players[i].Score);
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