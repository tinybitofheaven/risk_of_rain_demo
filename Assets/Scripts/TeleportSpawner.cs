using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TeleportSpawner : MonoBehaviour
{
    private bool isEnding = false, isBossSpawned = false, isTimeToTeleport = false;
    public bool isCountingDown = false;
    [SerializeField] private TextMeshProUGUI instructionTxt, playerInstructionTxt, bossHealthTxt;
    [SerializeField] private GameObject boss, timeBar, stayAliveObject, resultScreen, bossToggle, bossHealthBar;
    private int timer = 4;

    void Update()
    {
        if (isEnding) {
            if (!isBossSpawned) {
                boss.SetActive(true);
                isBossSpawned = true;
            }
            if (!isCountingDown) {
                StartCoroutine(countDown());
                instructionTxt.text = "Stay Alive!";
                stayAliveObject.SetActive(true);
                bossToggle.SetActive(true);
            }
            if (stayAliveObject.activeSelf) {
                timeBar.transform.localScale = new Vector3(Mathf.Min(1,(90-timer)/90.0f), 1, 1);
                playerInstructionTxt.gameObject.SetActive(true);
                playerInstructionTxt.text = "<color=white>" + (90 - timer) + "/" + 90 + " Seconds Left";
                if (timer <= 0) {
                    isCountingDown = false;
                    instructionTxt.text = "Press <color=#eecf7a>'E' <color=white>to end the demo";
                    FindObjectOfType<Timer>().timerIsRunning = false;
                }
            }
            bGolem bgolem = boss.GetComponent<bGolem>();
            bossHealthBar.transform.localScale = new Vector3(Mathf.Max(0,bgolem.currHealth * 1.0f/bgolem.entityData.startingHealth), 1, 1);
            bossHealthTxt.text = Mathf.Max(0,bgolem.currHealth)+"/"+bgolem.entityData.startingHealth;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            if (timer > 0) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    isEnding = true;
                }
            } else {
                if (Input.GetKeyDown(KeyCode.E)) {
                    resultScreen.SetActive(true);
                    resultScreen.GetComponent<ResultScreen>().showWinScreen();   
                }
            }
        }
    }
    void OnTriggerStay2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            if (timer > 0) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    isEnding = true;
                }
            } else {
                if (Input.GetKeyDown(KeyCode.E)) {
                    resultScreen.SetActive(true);
                    resultScreen.GetComponent<ResultScreen>().showWinScreen();   
                }
            }
        }
    }

    IEnumerator countDown() {
        isCountingDown = true;
        yield return new WaitForSeconds(1.0f);
        timer--;
        if (timer > 0) {
            StartCoroutine(countDown());
        }
    }
}
