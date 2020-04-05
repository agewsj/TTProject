using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerInfo
{
    public float attack;
}


public class Player : MonoBehaviour
{

    public PlayerInfo p_Info;

    public void SetPlayerInfo()
    {
        p_Info.attack = 5;
    }
}
