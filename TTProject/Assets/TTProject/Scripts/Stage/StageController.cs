using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Stage
{
    Stage1,
    Stage2,
    Stage3,
    Stage4
}

public class StageController : MonoBehaviour
{
    [Header("Stage State")]
    public Stage stageState = Stage.Stage1;

    [Header("List")]
    public List<RawImage> stageRawImageList = new List<RawImage>();    
    
    [Header("Background Speed Value")]
    public List<float> offsetSpeedList = new List<float>();
    public List<float> offsetValueList = new List<float>();

    [Header("Resource")]
    public List<Texture> stageImageList = new List<Texture>();
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isStageClear == true)
        {            
            for (int i = 0; i < stageRawImageList.Count; i++)
            {
                offsetValueList[i] += Time.deltaTime * offsetSpeedList[i];

                stageRawImageList[i].material.SetTextureOffset("_MainTex", new Vector2(offsetValueList[i], 0));
            }
        }       
    }

    public void SetStageTexture(Stage _stageNum)
    {
        stageState = _stageNum;

        for (int i = 0; i < stageRawImageList.Count; i++)
        {
            stageRawImageList[i].texture = stageImageList[i + ((int)stageState * 3)];
        }        
    }
}
