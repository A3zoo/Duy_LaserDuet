using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public void Start()
    {
        OpenApp();
    }
    public void OpenApp()
    {
        SoundManager.Instance._fxMusicBGBase.Play("Hypnotic-Puzzle");
        DataManager.Instance.OpenApp();
        StartCoroutine(LoadSceneMain(4f));
    }

    private IEnumerator LoadSceneMain(float a)
    {
        yield return new WaitForSeconds(a);
        LoadScene("MainGameSence");
    }

    public void StartGame()
    {
        GamePlayManager.Instance.StartGamePlay();
    }

    public void EndGame()
    {
        OnsShowHightScore();
    }

    public void OnsShowHightScore()
    {
        GameObject prefab = GetResourceFile<GameObject>("Panel");
        if (prefab != null)
        {
            Debug.Log(-1);
            GameObject popup = GameObject.Instantiate(prefab);
        }
    }
    public void Reload()
    {
        //GamePlayManager.Instance.EndGame();
    }
    public void LoadScene(string str)
    {
        SceneManager.LoadSceneAsync(str);
    }

    public T GetResourceFile<T>(string path) where T : Object
    {
        return Resources.Load<T>(path) as T;
    }

    public void UpScore()
    {
        UiManager.Instance.UpScore(1);
        DataManager.Instance.ChangeData(int.Parse(UiManager.Instance.scoreText.text));
    }    

    public void EndGamePlay()
    {
        SoundManager.Instance._fxSoundBase.Play("die");
        ObstacleManager.Instance.EndGamePlay();
        DataManager.Instance.Save();
        UiManager.Instance.ShowPanelHightScore();
        StartCoroutine(LoadSceneMain(3f));
    }    

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}

public class HighScoreData
{
    public int diem = 0;
    public HighScoreData()
    { }
    public HighScoreData(int diem)
    {
        this.diem = diem;
    }
}
