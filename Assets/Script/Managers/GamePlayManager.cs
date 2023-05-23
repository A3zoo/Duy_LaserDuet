using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoSingleton<GamePlayManager>
{
    public GameObject Player;
    private bool isStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        StartGamePlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPlayer()
    {
        return Player;
    }

    void StartUp()
    {

    }    

    public void StartGamePlay()
    {
        isStarted = true;
        Player.GetComponent<Player>().Run();
        ObstacleManager.Instance.StartGamePlay();
    }    

    public void EndGamePlay()
    {
        Player.GetComponent<Player>().Stop();
        ObstacleManager.Instance.EndGamePlay();
    }    

    void GetPlayerAction()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
