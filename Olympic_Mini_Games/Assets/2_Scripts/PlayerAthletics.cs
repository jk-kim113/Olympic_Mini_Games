using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAthletics : MonoBehaviour
{
    Rigidbody mRB;

    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        mRB.velocity = new Vector3(0, 0, 100);
    }

    public void StartButton()
    {
        Debug.Log("Click");
        //mRB.AddForce( transform.forward * 100f);
        //mRB.velocity = Vector3.forward * 100f;
        mRB.velocity = new Vector3(0, 0, 10000);
    }
}
