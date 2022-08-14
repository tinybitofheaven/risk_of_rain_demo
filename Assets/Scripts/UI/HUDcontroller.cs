using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDcontroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cointxt, difftxt, missiontxt, lvltxt, hptxt, CDtxt2, CDtxt3, CDtxt4;
    [SerializeField] private GameObject immunebar, abilityCD2, abilityCD3, abilityCD4;
    [SerializeField] private RawImage damagebar, hpbar, expbar;

    private PlayerController player;
    private void Start()
    {
        immunebar.SetActive(false);
        player = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        cointxt.text = GameManager.FindInstance().coins + "";
        // Debug.Log(GameManager.FindInstance().coins);
        hptxt.text = Mathf.Max(0, (int)GameManager.FindInstance().health) + "/" + Mathf.Max((int)GameManager.FindInstance().maxhp);
        hpbar.transform.localScale = new Vector3(Mathf.Max(0, GameManager.FindInstance().health) / GameManager.FindInstance().maxhp, 1, 1);
        if (damagebar.transform.localScale.x - hpbar.transform.localScale.x <= 0.01)
        {
            damagebar.transform.localScale = hpbar.transform.localScale;
        }
        else
        {
            damagebar.transform.localScale = Vector3.Lerp(damagebar.transform.localScale, hpbar.transform.localScale, 0.02f);
        }
        if (FindObjectOfType<PlayerController>().rolling)
        {
            immunebar.SetActive(true);
        }
        else
        {
            immunebar.SetActive(false);
        }


        if (player.Shoot2Counter != 0 && player.Shoot2Counter < player.shoot2CD)
        {
            abilityCD2.SetActive(true);
            CDtxt2.text = (int)(player.Shoot2Counter) + "";
        }
        else
        {
            abilityCD2.SetActive(false);
        }
        if (player.Shoot3Counter != 0 && player.Shoot3Counter < player.shoot3CD)
        {
            abilityCD3.SetActive(true);
            CDtxt3.text = (int)(player.Shoot3Counter) + "";
        }
        else
        {
            abilityCD3.SetActive(false);
        }
        if (player.Shoot4Counter != 0 && player.Shoot4Counter < player.shoot4CD)
        {
            abilityCD4.SetActive(true);
            CDtxt4.text = (int)(player.Shoot4Counter) + "";
        }
        else
        {
            abilityCD4.SetActive(false);
        }
    }
}
