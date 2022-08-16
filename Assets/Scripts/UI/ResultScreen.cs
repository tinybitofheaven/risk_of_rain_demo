using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelTxt, timeTxt, killTxt, BossTxt, itemTxt, goldTxt, purchaseTxt, TitleTxt;
    public int killCount = 0;

    void Update()
    {
        Time.timeScale = 0;
        levelTxt.text = 1 + GameManager.FindInstance().exp / 100+"";
        timeTxt.text = FindObjectOfType<Timer>().timeText.text;
        goldTxt.text = GameManager.FindInstance().coins+"";
        killTxt.text = killCount+"";
    }

    public void showWinScreen() {
        TitleTxt.text = "Win, Thank you for playing the demo!";
        
    }

    public void showLossScreen() {
    }
}
