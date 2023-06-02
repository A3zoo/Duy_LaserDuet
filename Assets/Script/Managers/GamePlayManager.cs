using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoSingleton<GamePlayManager>
{
    public GameObject Player;
    public bool isStarted;
    public float timeToUpScore = 2;
    public float scoreTimer = 0;
    public int math = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartGamePlay();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
            UpScore();
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
        ObstacleManager.Instance.StartGamePlay();
        Player.GetComponent<Player>().Run();
    }    

    public void EndGamePlay()
    {
        isStarted = false;
        Player.GetComponent<Player>().Stop();
        ObstacleManager.Instance.EndGamePlay();
    }    

    public void UpScore()
    {
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= timeToUpScore)
        {
            scoreTimer = 0;
            UiManager.Instance.UpScore(1);
        }
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
