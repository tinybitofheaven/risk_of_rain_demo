using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
