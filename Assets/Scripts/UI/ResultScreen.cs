using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelTxt, timeTxt, killTxt, killedbyTxt, BossTxt, itemTxt, goldTxt, purchaseTxt, TitleTxt;
    
    void Update()
    {
        Time.timeScale = 0;
        levelTxt.text = 1 + GameManager.FindInstance().exp / 100+"";
        timeTxt.text = FindObjectOfType<Timer>().timeText.text;
        goldTxt.text = GameManager.FindInstance().coins+"";
        killTxt.text = GameManager.FindInstance().kills+"";
        BossTxt.text = GameManager.FindInstance().bossKill+"";
        itemTxt.text = GameManager.FindInstance().items+"";
        purchaseTxt.text = GameManager.FindInstance().purchases+"";
        killedbyTxt.text = "Killed by: "+GameManager.FindInstance().killedBy;
    }

    public void showWinScreen() {
        TitleTxt.text = "Win, Thank you for playing the demo!";
        
    }

    public void showLossScreen() {
    }

    public void goback()
    {
        SceneManager.LoadScene(0);
    }

    public void tryagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
