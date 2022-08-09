using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDcontroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cointxt, difftxt, missiontxt, lvltxt, hptxt;
    [SerializeField] private RawImage damagebar, hpbar, expbar;

    private void Update() 
    {
        cointxt.text = GameManager.FindInstance().coins+"";
        Debug.Log(GameManager.FindInstance().coins);
    }
}
