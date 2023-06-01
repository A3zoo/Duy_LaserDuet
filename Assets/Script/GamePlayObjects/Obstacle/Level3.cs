using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Obstacle
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
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, Random.Range(-180, 180));
        this.transform.localScale = new Vector3(0.8f, 0.2f, 1);
        MoveY();
    }
}
