using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    public bool isStageClear = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
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

        StartCoroutine(dellayStopStageMove());
    }

    IEnumerator dellayStopStageMove()
    {
        yield return new WaitForSeconds(2f);

        isStageClear = false;

        UIManager.Instance.playerUIController.SetMonsterInfo();
    }
}
