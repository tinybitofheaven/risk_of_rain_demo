using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    private ItemController item;
    // Start is called before the first frame update
    void Start()
    {
        item = FindObjectOfType<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!item.feather)
            {
                item.feather = true;
            }
            Destroy(gameObject);
        }
    }
}
