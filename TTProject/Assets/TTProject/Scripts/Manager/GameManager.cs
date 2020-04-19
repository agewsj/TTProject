using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    public int stageNum = 0;
    public int stageThemeNum = 0;
    public bool isStageClear = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        stageNum = 0;
        stageThemeNum = 0;
        isStageClear = false;

        UIManager.Instance.InitUIManager();
    }

    private void Update()
    {
        if (isStageClear == true)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            UIManager.Instance.SetPlayerAttack();
        }
    }

    public void SetStageClear()
    {
        isStageClear = true;

        stageNum = stageNum + 1;
        if (stageNum == 2)
        {
            stageNum = 0;
            stageThemeNum++;

            if (stageThemeNum > 3)
            {
                stageThemeNum = 0;
            }
        }

        Debug.Log(stageThemeNum);
        UIManager.Instance.stageController.SetStageTexture((Stage)stageThemeNum);

        StartCoroutine(dellayStopStageMove());
    }

    IEnumerator dellayStopStageMove()
    {
        yield return new WaitForSeconds(2f);

        isStageClear = false;

        UIManager.Instance.playerUIController.SetMonsterInfo();
    }
}
