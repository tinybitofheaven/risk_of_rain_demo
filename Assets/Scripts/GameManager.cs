using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int coins = 0;
    public GameObject damageNumberPrefab;

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

    public void SpawnDamageNumber(int damage, RaycastHit2D hitInfo)
    {
        int count = 0;
        while (damage > 0)
        {
            GameObject num = Instantiate(damageNumberPrefab, new Vector2(hitInfo.point.x + 0.1f * count, hitInfo.point.y), Quaternion.identity);
            num.GetComponent<DamageNumber>().damage = damage % 10;
            damage = damage / 10;
            count--;
        }
    }
}
