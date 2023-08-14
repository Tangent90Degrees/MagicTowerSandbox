using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static Player Player { get; private set; }

    public static bool RegisterPlayer(Player player)
    {
        if (Player && player)
        {
            return false;
        }
        else
        {
            Player = player;
            return true;
        }
    }

}
