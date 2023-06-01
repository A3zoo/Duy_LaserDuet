using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Obstacle
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
        this.transform.localScale = new Vector3(0.8f,0.2f,1);
        MoveY();
    }
}
