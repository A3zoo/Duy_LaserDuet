using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public virtual void MoveY()
    {
        this.transform.DOMoveY(-10f, 5).SetEase(Ease.Linear).OnComplete(() =>
        {
            ObstacleManager.Instance.ReturnObjectToContainer(this.gameObject);
        }).OnUpdate(() =>
        {
            if (ObstacleManager.Instance.IsEndGame)
                DOTween.KillAll();
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObstacleManager.Instance.CollidedWithPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ObstacleManager.Instance.CollidedWithPlayer();
    }

    public virtual void StartRun()
    {
        this.transform.position = new Vector3(Random.Range(-2f, 2f), this.transform.position.y, this.transform.position.z);
    }
}
