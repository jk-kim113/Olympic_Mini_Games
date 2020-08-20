using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameStateStart : FSMSingleton<IngameStateStart>, IFSMState<IngameStateManager>
{
    public void Enter(IngameStateManager e)
    {
        e.mNowGameState = IngameStateManager.eGameState.Start;
        e.mBaseManager.GameStart();
    }

    public void Execute(IngameStateManager e)
    {
        
    }

    public void Exit(IngameStateManager e)
    {
        Debug.Log(" -- SampleStateInit Exit ");
    }
}
