using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct MonsterInfo
{
    public int Nowhp;
    public int Maxhp;
}


public class Monster : Common
{
    public Slider monsterHpBar;
    public MonsterInfo m_Info;

    
    public void SetMonsterInfo()
    {
        m_Info.Nowhp = 100;
        m_Info.Maxhp = 100;

        Debug.Log(m_Info.Nowhp);

        SetMonsterUI();
    }

    public void HitMonster(int _damage)
    {
        m_Info.Nowhp = m_Info.Nowhp - _damage;

        SetMonsterUI();

        SetAnimatorState(AnimationState.Hit);
    }    

    public void SetMonsterUI()
    {        
        monsterHpBar.minValue = 0;
        monsterHpBar.maxValue = m_Info.Maxhp;
        monsterHpBar.value = m_Info.Nowhp;

        if (m_Info.Nowhp <= 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.SetStageClear();
        }
    }
}
