using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoSingleton<UiManager>
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartUp()
    {

    }    

    public void StartGamePlay()
    {
        SceneManager.LoadSceneAsync("GamePlaySence");
    }    

    public void UpScore(int a)
    {
        this.scoreText.text = (int.Parse(this.scoreText.text) + a).ToString();
    }    
}
