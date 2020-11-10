using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameStatePlay : FSMSingleton<IngameStatePlay>, IFSMState<IngameStateManager>
{
    public void Enter(IngameStateManager e)
    {
        Debug.Log("Play Game");
    }

    public void Execute(IngameStateManager e)
    {

    }

    public void Exit(IngameStateManager e)
    {

    }
}
