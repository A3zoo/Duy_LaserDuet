using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleManager : MonoSingleton<ObstacleManager>
{
    GameObject rec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObject()
    {
        Vector3 insLocation = new Vector3(Random.Range(-2f, 2f), this.transform.position.y, this.transform.position.z);
        GameObject a = GameObject.Instantiate(rec, insLocation, rotation: Quaternion.identity);
        a.gameObject.AddComponent<Nomal>();
    }

    void StartUp()
    {

    }    

    public void StartGamePlay()
    {
        rec = Resources.Load<GameObject>("dox");
        InvokeRepeating("SpawnObject", 2f, 2f);
    }    

    public void EndGamePlay()
    {
        CancelInvoke("SpawnObject");
    }    

    public void CollidedWithPlayer()
    {
        Debug.Log(100);
        GamePlayManager.Instance.EndGamePlay();
    }    
}
