using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        Vector2 velocity = new Vector2(Random.Range(0, 2) * 2 - 1, 1f);
        gameObject.GetComponent<Rigidbody2D>().GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.FindInstance().coins++;
            Destroy(gameObject);
        }
    }
}
