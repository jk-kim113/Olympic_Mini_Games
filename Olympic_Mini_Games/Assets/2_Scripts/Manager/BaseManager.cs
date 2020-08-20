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
    public IngameStateManager.eGameState _GameState { get { return mStateMgr.mNowGameState; } }

    protected virtual void Start()
    {
        mStateMgr = GameObject.FindGameObjectWithTag("IngameStateManager").GetComponent<IngameStateManager>();
        mStateMgr.mBaseManager = this;
        mStateMgr.mNowGameKind = mGameKind;
        mStateMgr.InitState();
    }

    public abstract void GameStart();
}
