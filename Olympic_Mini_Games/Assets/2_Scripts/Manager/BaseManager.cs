using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    IngameStateManager.eGameKind mGameKind;
#pragma warning restore

    protected IngameStateManager mStateMgr;

    public string mGameState { get { return mStateMgr.ToString(); } }

    protected virtual void Start()
    {
        GameObject go = new GameObject("IngameStateMgr", typeof(IngameStateManager));
        mStateMgr = go.GetComponent<IngameStateManager>();
        mStateMgr.mNowGameKind = mGameKind;
        mStateMgr.InitState();
    }

    public abstract void GameStart();
}
