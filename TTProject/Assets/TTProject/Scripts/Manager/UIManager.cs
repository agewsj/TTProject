using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingleTon<UIManager>
{
    public StageController stageController;
    public PlayerUIController playerUIController;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void InitUIManager()
    {
        stageController.SetStageTexture(Stage.Stage1);

        playerUIController.SetPlayerInfo();
        playerUIController.SetMonsterInfo();
    }

    public void SetPlayerAttack()
    {
        Debug.Log("PlayerAttack");

        playerUIController.AttackPlayer();
    }
}
