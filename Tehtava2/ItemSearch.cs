
using System;
using System.Linq;

public class ItemSearch
{
    //TEHT - 3
    public static Item[] GetItems(Player player)
    {
        Item[] array_item = new Item[player.Items.Count()];

        int i = 0;
        foreach (Item item in player.Items)
        {
            array_item[i] = item;
            i++;
        }

        return array_item;
    }

    public static Item[] GetItemsWithLinq(Player player)
    {
        return player.Items.ToArray();
    }


    //Teht - 4
    public static Item FirstItem(Player player)
    {
        if (player.Items.Any())
        {
            return player.Items[0];
        }

        return null;
    }

    public static Item FirstItemWithLinq(Player player)
    {
        return player.Items.First();
    }

    public static void ProcessEachItem(Player player, Action<Item> process)
    {
        Item[] array = GetItemsWithLinq(player);

        for (int a = 0; a < array.Length; a++)
        {
            process(array[a]);
        }
    }

    public static void PrintItem(Item item)
    {
        Console.WriteLine(item.Id);
        Console.WriteLine(item.Level);
    }
}

