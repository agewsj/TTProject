using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public Player player;
    public Monster monster;

    public void SetPlayerInfo()
    {
        if (player.gameObject.activeInHierarchy == false)
        {
            player.gameObject.SetActive(true);
        }

        player.SetPlayerInfo();
    }

    public void SetMonsterInfo()
    {
        if (monster.gameObject.activeInHierarchy == false)
        {
            monster.gameObject.SetActive(true);
        }
        
        monster.SetMonsterInfo();
    }

    public void AttackPlayer()
    {
        monster.HitMonster((int)player.p_Info.attack);
    }
}
