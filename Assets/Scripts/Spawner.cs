﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static Spawner instance;

    public GameObject playerGO;

    public float spawnRange;
    public float minSpawnFrequency;
    public float maxSpawnFrequency;

    public int minSpawnAmount;
    public int maxSpawnAmount;
    public int enemyCount = 0;
    public int maxEnemies = 50;

    public GameObject[] enemyPrefabs;
    public LayerMask whatIsGround;
    public BoxCollider2D worldBounds;

    public static Spawner FindInstance()
    {
        return instance;
    }
    private void Awake()
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
        Invoke("SpawnEnemy", 3f);
    }

    //helper functions
    private Vector2 FindSpawn()
    {
        Bounds bounds = new Bounds(playerGO.transform.position, new Vector2(spawnRange * 2, spawnRange * 2));
        Vector2 _v = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
        return _v;
    }

    private void SpawnEnemy()
    {
        float randomTime = Random.Range(minSpawnFrequency, maxSpawnFrequency);
        bool functionCall = false;

        if (enemyCount < maxEnemies)
        {
            //spawn enemy
            Vector2 _v = FindSpawn();
            RaycastHit2D ground = Physics2D.Raycast(_v, Vector2.down, 5f, whatIsGround);
            RaycastHit2D air = Physics2D.Raycast(new Vector2(ground.point.x, ground.point.y), Vector2.up, 2f, whatIsGround);
            if (ground && !air)
            {
                int amount = Random.Range(minSpawnAmount, maxSpawnAmount);
                for (int i = 0; i < amount; i++)
                {
                    int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                    Instantiate(enemyPrefabs[enemyIndex],
                        new Vector2(ground.point.x + 0.5f * i,
                                    ground.point.y + enemyPrefabs[enemyIndex].GetComponent<BoxCollider2D>().size.y / 2),
                                    Quaternion.identity);
                    enemyCount++;
                }
            }
            else
            {
                functionCall = true;
                Invoke("SpawnEnemy", 0.5f);
            }

        }

        if (functionCall == false)
        {
            Invoke("SpawnEnemy", randomTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playerGO.transform.position, new Vector2(spawnRange * 2, spawnRange * 2));
    }

}
