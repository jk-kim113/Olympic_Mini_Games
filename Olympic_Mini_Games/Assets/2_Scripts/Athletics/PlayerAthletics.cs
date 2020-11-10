using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAthletics : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    float mAddVelocity = 3.0f;
    [SerializeField]
    float mExcellentHeight;
    [SerializeField]
    float mGoodHeight;
    [SerializeField]
    float mMissHeight;
#pragma warning restore

    Rigidbody mRB;
    Animator mAnimCtrl;
    bool mIsRunning = false;

    DetectGround[] mDetectGrArr = new DetectGround[2];

    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
        mAnimCtrl = GetComponent<Animator>();
    }

    private void Start()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("DectectGround");

        for(int n = 0; n < go.Length; n++)
        {
            mDetectGrArr[n] = new DetectGround();
            mDetectGrArr[n] = go[n].GetComponent<DetectGround>();
        }
    }

    private void Update()
    {
        mAnimCtrl.SetFloat("Speed", mRB.velocity.z);
    }

    private void FixedUpdate()
    {
        if(AthleticsManager.mInstance.mGameState == "IngamePlay")
        {
            if (mRB.velocity.z < 1.5f && mIsRunning)
            {
                mRB.velocity = new Vector3(0, 0, 1.5f);
            }
        }
    }

    public void StartButton()
    {
        AddVelocity(mAddVelocity * 3);
        mIsRunning = true;
        AthleticsManager.mInstance.StartGame();
    }

    public void RunButton(int type)
    {
        if(mDetectGrArr[type]._IsOnGround)
        {
            RaycastHit hit;
            if(Physics.Raycast(mDetectGrArr[type].transform.position, Vector3.down, out hit))
            {
                if(hit.collider.CompareTag("Ground"))
                {
                    float distance = mDetectGrArr[type].transform.position.y - hit.collider.transform.position.y;

                    if(distance < mExcellentHeight)
                    {
                        AddVelocity(mAddVelocity * 2);
                    }
                    else if(distance < mGoodHeight)
                    {
                        AddVelocity(mAddVelocity);
                    }
                    else if(distance < mMissHeight)
                    {
                        Debug.Log("Miss");
                    }
                }
            }
        }
    }

    void AddVelocity(float value)
    {
        mRB.velocity += new Vector3(0, 0, value);
    }
}
