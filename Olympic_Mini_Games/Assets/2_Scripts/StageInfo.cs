using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    IngameStateManager.eGameKind mGameKind;
#pragma warning restore

    public void ChangeScene()
    {
        SceneChangeManager._instance.StartLoadIngameScene(mGameKind.ToString() + "Scene");
    }
}
