using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Nomal : Obstacle
{
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public override void Move()
    {
        this.transform.DOMoveY(-10f, 5).SetEase(Ease.Linear).SetId("nomal").OnComplete(() =>
        {
            Destroy(gameObject);
        }); 
    }

    private bool IsObjectVisible()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 1 && viewportPosition.y < 1.2);
    }

}
