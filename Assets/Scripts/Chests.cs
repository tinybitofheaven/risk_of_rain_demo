using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    public int minCost = 20;
    public int maxCost = 55;
    public int cost;
    public GameObject item;

    private bool canOpen;
    private Animator anim;

    private void Start()
    {
        cost = Random.Range(minCost, maxCost);
        anim = gameObject.GetComponent<Animator>();
        //TODO: set random item
    }

    private void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("open", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
        }
    }
}
