using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int coins = 0;

    public static GameManager FindInstance()
    {
        return instance; //that's just a singletone as the region says
    }

    private void Awake() //this happens before the game even starts and it's a part of the singletone
    {
        if (instance != null && instance != this)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            Debug.Log("destroy");
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(RemoveBodies());
    }

    private IEnumerator RemoveBodies()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            GameObject[] deadEnemies = GameObject.FindGameObjectsWithTag("DeadEnemy");
            foreach (GameObject enemy in deadEnemies)
            {
                // Debug.Log("dead: " + enemy.name);
                Destroy(enemy);
            }
        }
    }
}
