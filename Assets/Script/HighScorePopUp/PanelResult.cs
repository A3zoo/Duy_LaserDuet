using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelResult : MonoBehaviour
{
    public Text score;
    public Text hightScore;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadData()
    {
        score.text = DataManager.Instance.recentUser.diem.ToString();
        hightScore.text = DataManager.Instance.HightScoreuser.diem.ToString();
    }
}
