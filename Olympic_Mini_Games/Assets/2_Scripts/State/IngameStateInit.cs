using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameStateInit : FSMSingleton<IngameStateInit>, IFSMState<IngameStateManager>
{
	public void Enter(IngameStateManager e)
	{
        e.mNowGameState = IngameStateManager.eGameState.Init;
        Instantiate(Resources.Load("UI/GameStartWindow") as GameObject).GetComponent<GameStartWindow>().InitMessage(e.mNowGameKind);
    }

    public void Execute(IngameStateManager e)
    {
        
    }

    public void Exit(IngameStateManager e)
	{
        
	}
}
