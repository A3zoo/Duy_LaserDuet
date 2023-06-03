using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ObstacleManager : MonoSingleton<ObstacleManager>
{
    private bool _isEndGame;

    public float _timerToChangeLevel = 0;

    public float _timeToSpaObject = 2;

    public int _level = 1;


    enum TimeToChangeLevel
    {
        level2 = 20,
        Level3 = 40,
        Level4 = 50,
        level5 = 70,
        freelevel
    }

    public bool IsEndGame
    {
        get { return _isEndGame; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeAndChangeLevel();
    }

    void SpawnObject()
    {
        GameObject a = PoolingManager.Instance.RequestObject(0);
        switch (_level)
        {
            case 1:
                a.gameObject.AddComponent<Level1>(); break;
            case 2:
                a.gameObject.AddComponent<Level2>(); break;
            case 3:
                a.gameObject.AddComponent<Level3>(); break;
            case 4:
                a.gameObject.AddComponent<Level4>(); break;
            case 5:
                a.gameObject.AddComponent<Level5>(); break;
            default:
                RanDomScrip(a); break;
        }
    }

    public void RanDomScrip(GameObject a)
    {
        int tempt = Convert.ToInt16(UnityEngine.Random.Range(1f, 5.9f));
        switch (tempt)
        {
            case 1:
                a.gameObject.AddComponent<Level1>(); break;
            case 2:
                a.gameObject.AddComponent<Level2>(); break;
            case 3:
                a.gameObject.AddComponent<Level3>(); break;
            case 4:
                a.gameObject.AddComponent<Level4>(); break;
            case 5:
                a.gameObject.AddComponent<Level5>(); break;
        }
    }
    
    void StartUp()
    {

    }    

    public void StartGamePlay()
    {
        InvokeRepeating("SpawnObject", _timeToSpaObject, _timeToSpaObject);
    }    

    public void DownTimeToSpaObject()
    {
        if (_timeToSpaObject >= 1.3)
            _timeToSpaObject -= 0.1f;
    }    

    public void ChangeSpeedObstacle()
    {

    }    

    public void EndGamePlay()
    {
        CancelInvoke("SpawnObject");
        _isEndGame = true;
    }    

    public void CollidedWithPlayer()
    {
        Debug.Log(100);
        ReturnAllObstacles();
        GamePlayManager.Instance.EndGamePlay();
    }    

    public void ReturnAllObstacles()
    {
        GameObject[] ObstaclesObject = GameObject.FindGameObjectsWithTag("Obstacles");
        foreach (GameObject a in ObstaclesObject)
        {
            ReturnObjectToContainer(a);
        }    
        
    }

    public void ReturnObjectToContainer(GameObject a)
    {
        PoolingManager.Instance.ReturnObject(0, a);
    }    

    public void CheckTimeAndChangeLevel()
    {
        _timerToChangeLevel += Time.deltaTime;
        if (_timerToChangeLevel >= Convert.ToInt16(TimeToChangeLevel.level5))
        {
            _level = 6;
            InvokeRepeating("DownTimeToSpaObject", 10, 10);
        }   
        else if(_timerToChangeLevel >= Convert.ToInt16(TimeToChangeLevel.level5))
            _level = 5;
        else if (_timerToChangeLevel >= Convert.ToInt16(TimeToChangeLevel.Level4))
            _level = 4;
        else if (_timerToChangeLevel >= Convert.ToInt16(TimeToChangeLevel.Level3))
            _level = 3;
        else if (_timerToChangeLevel >= Convert.ToInt16(TimeToChangeLevel.level2))
            _level = 2;
    }
}
