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

    static AthleticsManager mUniqueInstance;
    public static AthleticsManager mInstance { get { return mUniqueInstance; } }

    private void Awake()
    {
        mUniqueInstance = this;
    }

    protected override void Start()
    {
        base.Start();

        mStartBtn.SetActive(false);
        for (int n = 0; n < mTimingBtn.Length; n++)
            mTimingBtn[n].SetActive(false);
    }

    private void Update()
    {
        if (mStateMgr.ToString() == "IngamePlay")
        {
            // Ingame Time Check
        }
    }

    public void StartGame()
    {
        mStartBtn.SetActive(false);
        for (int n = 0; n < mTimingBtn.Length; n++)
            mTimingBtn[n].SetActive(true);
    }

    public override void GameStart()
    {
        
    }
}
