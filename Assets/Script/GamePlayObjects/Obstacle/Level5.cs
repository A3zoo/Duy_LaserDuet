using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level5 : Obstacle
{
    public float swayDuration = 2f; // Thời gian di chuyển qua lại
    public float swayDistance = 1f;

    Tween mytween;

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
        this.transform.localScale = new Vector3(0.8f, 0.2f, 1);
        Action();
        MoveY();
    }

    public void Action()
    {
        SwayObject();
    }

    private void SwayObject()
    {
        mytween = transform.DORotate(new Vector3(0f, 0f, 360), 4f, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear)
            .OnUpdate(() => {
                if (transform.position.y == -10f)
                    mytween.Kill();
            });
    }
}
