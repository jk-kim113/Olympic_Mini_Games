using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGround : MonoBehaviour
{
    public enum eFootType
    {
        LeftFoot        = 0,
        RightFoot
    }

#pragma warning disable 0649
    [SerializeField]
    eFootType mFootType;
#pragma warning restore

    bool mIsOnGround;
    public bool _IsOnGround { get { return mIsOnGround; } }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            mIsOnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            mIsOnGround = false;
        }
    }
}
