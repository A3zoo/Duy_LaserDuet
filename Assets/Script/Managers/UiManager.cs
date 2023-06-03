using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoSingleton<UiManager>
{
    public Text scoreText;
    public PanelResult HightScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGamePlay()
    {
        OnRing();
        GameManager.Instance.LoadScene("GamePlaySence");
    }    

    public void UpScore(int a)
    {
        Debug.Log(10000);
        this.scoreText.text = (int.Parse(this.scoreText.text) + a).ToString();
    }    

    public void OnRing()
    {
        SoundManager.Instance._fxMusicBGBase.Play("MouthPop");
    }

    public void ShowPanelHightScore()
    {
        HightScore.enabled = true;
        HightScore.gameObject.SetActive(true);
    }    
}
