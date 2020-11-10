using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartWindow : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    Text mMessageText;
#pragma warning restore

    IngameStateManager mIngmaeStateMgr;
    int mStartID;
    int mEndID;

    public void InitMessage(IngameStateManager e)
    {
        mIngmaeStateMgr = e;
        mStartID = TableManager._instance.Get(eTableType.SceneInfo).ToI((int)mIngmaeStateMgr.mNowGameKind + 1, "StartIndex");
        mEndID = TableManager._instance.Get(eTableType.SceneInfo).ToI((int)mIngmaeStateMgr.mNowGameKind + 1, "EndIndex");
        NextMessage();
    }
    
    public void NextMessage()
    {
        if(mStartID > mEndID)
        {
            mIngmaeStateMgr.ChangeState(IngameStateStart.Instance);
            gameObject.SetActive(false);
            return;
        }

        mMessageText.text = TableManager._instance.Get(eTableType.ExplainDialog)._datas[(mStartID++).ToString()]["Explain"];
    }
}
