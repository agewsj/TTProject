using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [Header("Player")]
    public GameObject playerObject;
    public Vector2 playerPos;
    public Player player;

    [Header("Monster")]
    public GameObject monsterObject;
    public Vector2 monsterPos;
    public Monster monster;

    public void SetPlayerInfo()
    {
        if (player == null)
        {
            GameObject go = Instantiate(playerObject, transform);
            go.GetComponent<RectTransform>().anchoredPosition = playerPos;

            player = go.GetComponent<Player>();
        }

        if (player == null)
        {
            Debug.Log("Player GetComponent Null");
            return;
        }            

        if (player.gameObject.activeInHierarchy == false)
        {
            player.gameObject.SetActive(true);
        }

        player.SetPlayerInfo();
    }

    public void SetMonsterInfo()
    {
        if (monster == null)
        {
            GameObject go = Instantiate(monsterObject, transform);
            go.GetComponent<RectTransform>().anchoredPosition = monsterPos;

            monster = go.GetComponent<Monster>();
        }

        if (monster == null)
        {
            Debug.Log("Monster GetComponent Null");
            return;
        }

        if (monster.gameObject.activeInHierarchy == false)
        {
            monster.gameObject.SetActive(true);
        }
        
        monster.SetMonsterInfo();
    }

    public void AttackPlayer()
    {
        if (player == null || monster == null)
            return;

        player.SetAttack();

        monster.HitMonster((int)player.p_Info.attack);
    }
}
