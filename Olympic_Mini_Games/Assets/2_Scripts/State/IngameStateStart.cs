using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameStateStart : FSMSingleton<IngameStateStart>, IFSMState<IngameStateManager>
{
    float _timeCheck;
    CountDown _countDownWnd;

    public void Enter(IngameStateManager e)
    {
        _countDownWnd = UIManager._instance.OpenWnd<CountDown>(UIManager.eKindWindow.CountDownWindow);
    }

    public void Execute(IngameStateManager e)
    {
        _timeCheck += Time.deltaTime;
        if(_timeCheck > 1.0f)
        {
            _timeCheck = 0;
            if (!_countDownWnd.ChangeCountBG())
            {
                _countDownWnd.gameObject.SetActive(false);
                e.ChangeState(IngameStatePlay.Instance);
            }
        }
    }

    public void Exit(IngameStateManager e)
    {
        Debug.Log(" -- SampleStateInit Exit ");
    }
}
