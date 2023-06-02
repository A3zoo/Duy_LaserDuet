using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Transform _popUpContainer;
    public void Start()
    {
        OpenApp();
    }
    public void OpenApp()
    {
        DataManager.Instance.OpenApp();
        OnShowDialog<HighScorePopup>("hightscore");
    }
    public void OnShowDialog<T>(string path, object data = null, UnityEngine.Events.UnityAction callbackCompleteShow = null) where T : BaseDialog
    {
        GameObject prefab = GetResourceFile<GameObject>(path);
        Debug.Log(prefab);
        Debug.Log("Onshow roi ne");
        if (prefab != null)
        {
            T objectSpawned = (Instantiate(prefab, _popUpContainer)).GetComponent<T>();
            Debug.Log(objectSpawned);
            if (objectSpawned != null)
            {
                objectSpawned.OnShow(data, callbackCompleteShow);
            }
        }
    }
    public void StartGame()
    {
        GamePlayManager.Instance.StartGamePlay();
        //DataManager.Instance.CreateUser();
        //GameUi.Instance.start.gameObject.SetActive(false);
        closePanel();
    }
    public void EndGame()
    {
        OnShowDialog<HighScorePopup>("hightscore");
        //GameUi.Instance.Init();
        //GamePlayManager.Instance.Init();
    }
    public void Reload()
    {
        //GamePlayManager.Instance.EndGame();
    }
    public void LoadScene()
    {

    }

    public void closePanel()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag("ui");
        foreach (GameObject i in a)
        {
            i.GetComponent<HighScorePopup>().OnHide();
        }
    }

    /// <summary>
    /// Load m�?t file t?? folder Resource
    /// </summary>
    /// <typeparam name="T">Ki�?u d?? li�?u ho??c 1 component</typeparam>
    /// <param name="path">????ng d�?n file, bo? ?u�i file va? ph�?n /Resource</param>
    /// <returns></returns>
    public T GetResourceFile<T>(string path) where T : Object
    {
        return Resources.Load<T>(path) as T;
    }

    /// <summary>
    /// Ta?o ?i�?m gia? ?�? ?�? l�n cho user, ca?c ba?n se? thay b??ng Ha?m l�?y danh sa?ch highscore ????c l?u d???i ma?y
    /// </summary>
    /// <returns></returns>
    public List<HighScoreData> GenerateFakeHighScore()
    {
        List<HighScoreData> _scores = new List<HighScoreData>();
        //foreach (HighScoreData i in DataManager.Instance.playerList)
        //{
        //    _scores.Add(i);
        //}
        return _scores;
    }
}

public class HighScoreData
{
    public string time;
    public int diem;
    public HighScoreData()
    { }
    public HighScoreData(string date, int diem)
    {
        time = date;
        this.diem = diem;
    }
}
