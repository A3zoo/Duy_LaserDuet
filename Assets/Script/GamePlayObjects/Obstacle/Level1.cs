using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level1 : Obstacle
{
    // Start is called before the first frame update
    void Start()
    {
        StartRun();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void StartRun()
    {
        base.StartRun();
        this.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        MoveY();
    }    

}
