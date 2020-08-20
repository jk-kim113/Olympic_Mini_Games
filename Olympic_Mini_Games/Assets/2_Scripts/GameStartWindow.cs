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

    IngameStateManager.eGameKind mGameKind;
    int mMessageID;

    public void InitMessage(IngameStateManager.eGameKind kind)
    {
        mGameKind = kind;
        mMessageID = 0;
        NextMessage();
    }

    public void NextMessage()
    {
        // Check Key Exists
        mMessageText.text = ResourcePoolManager._instance.GetStageExplain(mGameKind, mMessageID++);
    }
}
