using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Move()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObstacleManager.Instance.CollidedWithPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ObstacleManager.Instance.CollidedWithPlayer();
    }
}
