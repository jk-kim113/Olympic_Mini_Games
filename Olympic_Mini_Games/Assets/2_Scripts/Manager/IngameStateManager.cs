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

    eGameKind mCurrentGameKind;
    public eGameKind mNowGameKind { get { return mCurrentGameKind; } set { mCurrentGameKind = value; } }

    public void InitState()
    {
        InitState(this, IngameStateInit.Instance);
    }

    void Update()
    {
        FSMUpdate();
    }
}
