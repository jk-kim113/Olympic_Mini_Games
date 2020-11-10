using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameStateInit : FSMSingleton<IngameStateInit>, IFSMState<IngameStateManager>
{
    GameStartWindow _gameStartWnd;

	public void Enter(IngameStateManager e)
	{
        _gameStartWnd = UIManager._instance.OpenWnd<GameStartWindow>(UIManager.eKindWindow.GameStartWindow);
        _gameStartWnd.InitMessage(e);
    }

    public void Execute(IngameStateManager e)
    {

    }

    public void Exit(IngameStateManager e)
	{
        
	}
}
