using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthleticsManager : BaseManager
{
#pragma warning disable 0649
    [SerializeField]
    GameObject mStartBtn;
    [SerializeField]
    GameObject[] mTimingBtn;
#pragma warning restore

    float mTimeCheck;
    CountDown mCountDownWnd;
    bool mIsCount;

    static AthleticsManager mUniqueInstance;
    public static AthleticsManager mInstance { get { return mUniqueInstance; } }

    private void Awake()
    {
        mUniqueInstance = this;
    }

    protected override void Start()
    {
        base.Start();

        mCountDownWnd = GameObject.Find("CountDownUI").GetComponent<CountDown>();
        mCountDownWnd.gameObject.SetActive(false);

        mStartBtn.SetActive(false);
        for (int n = 0; n < mTimingBtn.Length; n++)
            mTimingBtn[n].SetActive(false);
    }

    private void Update()
    {
        if(mIsCount)
        {
            mTimeCheck += Time.deltaTime;

            if(mTimeCheck > 1.0f)
            {
                mTimeCheck = 0;
                if(!mCountDownWnd.ChangeCountBG())
                {
                    mIsCount = false;
                    mStateMgr.mNowGameState = IngameStateManager.eGameState.Ingame;
                    mStartBtn.SetActive(true);
                }
            }
        }

        if (mStateMgr.mNowGameState == IngameStateManager.eGameState.Ingame)
        {
            // Ingame Time Check
        }
    }

    public void StartCountDown()
    {
        mCountDownWnd.gameObject.SetActive(true);
        mIsCount = true;
    }

    public void StartGame()
    {
        mStartBtn.SetActive(false);
        for (int n = 0; n < mTimingBtn.Length; n++)
            mTimingBtn[n].SetActive(true);
    }

    public override void GameStart()
    {
        StartCountDown();
    }
}
