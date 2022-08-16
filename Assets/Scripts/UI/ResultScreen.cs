using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelTxt, timeTxt, killTxt, BossTxt, itemTxt, goldTxt, purchaseTxt;

    void Update()
    {
        levelTxt.text = 1 + GameManager.FindInstance().exp / 100+"";
        timeTxt.text = FindObjectOfType<Timer>().timeText.text;    
        goldTxt.text = GameManager.FindInstance().coins+"";
    }
}
