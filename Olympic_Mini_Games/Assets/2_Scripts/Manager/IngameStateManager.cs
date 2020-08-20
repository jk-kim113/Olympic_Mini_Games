using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameStateManager : FSM<IngameStateManager>
{
    public enum eGameKind
    {
        Athletics       = 0,
        Archery,
        Tennis,
        Judo
    }

    public enum eGameState
    {
        Init        = 0,
        Start,
        Ingame,
        Result
    }

    eGameKind mCurrentGameKind;
    public eGameKind mNowGameKind { get { return mCurrentGameKind; } set { mCurrentGameKind = value; } }

    eGameState mCurrentGameState;
    public eGameState mNowGameState { get { return mCurrentGameState; } set { mCurrentGameState = value; } }

    BaseManager mBaseMgr;
    public BaseManager mBaseManager { get { return mBaseMgr; } set { mBaseMgr = value; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void InitState()
    {
        InitState(this, IngameStateInit.Instance);
    }

    void Update()
    {
        FSMUpdate();
    }
}
