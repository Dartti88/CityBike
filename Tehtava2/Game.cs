using System;
using System.Collections.Generic;
using System.Linq;

public class Game<T> where T : IPlayer
{
    private List<T> _players;

    public Game(List<T> players)
    {
        _players = players;
    }


    public T[] GetTop10Players()
    {
        // ... write code that returns 10 players with highest scores
        var selected_players = new T[10];
        for (int i = 0; i < 10; i++)
        {
            T best_player = _players.Aggregate((i1, i2) => i1.Score > i2.Score ? i1 : i2);
            selected_players[i] = best_player;
            //Console.WriteLine(best_player.Score);
            _players.Remove(best_player);
        }

        return selected_players;
    }

}