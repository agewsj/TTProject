using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerInfo
{
    public float attack;
}


public class Player : Common
{
    public PlayerInfo p_Info;

    public void SetInitPlayer()
    {
        SetAnimatorState(AnimationState.Idle);
        SetInitNormalAttackEffect();
    }

    public void SetPlayerInfo()
    {
        p_Info.attack = 5;
    }

    public void SetAttack()
    {
        SetAnimatorState(AnimationState.Attack);

        SetActiveNormalAttackEffect();
    }
}
