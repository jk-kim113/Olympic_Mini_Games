using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    float mMoveSpeed = 1.5f;
#pragma warning restore

    Vector3 mTargetPos;
    Vector3 mOriginPos;

    private void Awake()
    {
        mOriginPos = transform.position;
        RandomPosition();
    }

    private void Update()
    {
        if(Vector3.Distance(mTargetPos, transform.position) < 0.1)
        {
            RandomPosition();
        }

        //transform.position = Vector3.MoveTowards(transform.position, mTargetPos, Time.deltaTime * mMoveSpeed);
        transform.position = Vector3.Lerp(transform.position, mTargetPos, Time.deltaTime * mMoveSpeed);
        //Vector3.Lerp()
    }

    void RandomPosition()
    {
        Vector2 temp = Random.insideUnitCircle;
        mTargetPos = mOriginPos + new Vector3(temp.x * 0.2f, temp.y * 0.2f);
    }
}
