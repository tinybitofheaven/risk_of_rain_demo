using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TeleportSpawner : MonoBehaviour
{
    private bool isEnding = false, isBossSpawned = false;
    public bool isCountingDown = false;
    [SerializeField] private TextMeshProUGUI instructionTxt, playerInstructionTxt;
    [SerializeField] private GameObject boss, timeBar, stayAliveObject;
    private int timer = 90;

    void Start()
    {
        
    }

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
            }
            if (stayAliveObject.activeSelf) {
                timeBar.transform.localScale = new Vector3((90-timer)/90.0f, 1, 1);
                playerInstructionTxt.text = "<color=white>" + timer + "/" + 90 + " Seconds Left";
                if (timer <= 0)
                    isCountingDown = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            if (Input.GetKeyDown(KeyCode.E)) {
                isEnding = true;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collider) {
        if (collider.tag.Equals("Player")) {
            if (Input.GetKeyDown(KeyCode.E)) {
                isEnding = true;
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
