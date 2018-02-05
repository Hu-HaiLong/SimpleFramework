
using System.Collections.Generic;

public class UserData  {

    int xinqing;
    List<PlayerData> players;

    public UserData(List<PlayerData> players)
    {
        this.players = players;
    }

    public List<PlayerData> Players
    {
        get
        {
            return players;
        }

        set
        {
            players = value;
        }
    }
}
