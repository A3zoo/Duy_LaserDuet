using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject _ballA;
    public GameObject _ballB;
    public GameObject _circle;
    public int _stateRotage;
    public Tween _action;
    private bool isStarted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            GetAction();
        }    
    }

    public void Run()
    {
        isStarted = true;
    }    

    public void GetAction()
    {
        float Angle = _stateRotage == 1 ? 360f : -360f;
        if (_stateRotage == 0)
            _action = null;
        if (_action == null && _stateRotage != 0)
            _action = transform.DORotate(new Vector3(0f, 0f, Angle), 2f, RotateMode.WorldAxisAdd).SetId("RotagePlayer").SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void Stop()
    {
        isStarted = false;
        DOTween.Kill("RotagePlayer");
    }
}
