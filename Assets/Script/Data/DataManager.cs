using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : MonoSingleton<DataManager>
{
    public HighScoreData HightScoreuser;
    public HighScoreData recentUser;
    void Start()
    {
        recentUser = new HighScoreData(0);
    }

    void Update()
    {

    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("HightScore"))
        {
            string jsonData = PlayerPrefs.GetString("HightScore");

            if (!string.IsNullOrEmpty(jsonData))
            {
                HightScoreuser = JsonUtility.FromJson<HighScoreData>(jsonData);
            }
            else
            {
                HightScoreuser = new HighScoreData(0);
                return;
            }

        }

        else
        {
            HightScoreuser = new HighScoreData(0);
        }
    }

    public void ChangeData(int score)
    {
        this.recentUser.diem = score;
        if (recentUser.diem != 0 && HightScoreuser.diem < recentUser.diem)
        {
            HightScoreuser.diem = recentUser.diem;
        }
    }    

    public void Save()
    {
        PlayerPrefs.SetString("HightScore", (JsonUtility.ToJson(HightScoreuser)));
    }
    public void OpenApp()
    {
        LoadData();
    }
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
