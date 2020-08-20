using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryManager : BaseManager
{
    protected override void Start()
    {
        base.Start();
    }

    public override void GameStart()
    {
        Debug.Log("Archery Game Start");
    }
}
